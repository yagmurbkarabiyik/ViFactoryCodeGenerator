using Microsoft.AspNetCore.DataProtection;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Tea.Bll.Enums;
using Tea.Bll.Models;
using Tea.Core.Models;
using Tea.Core.Models.TokenModels;
using Tea.Domain.IdentityModels;
using Tea.Core.Services.TokenService;
using Tea.Core.Services;
using Tea.Bll.Dtos.AppUserDtos;
using Tea.Dal.Data.IDalRepos;
using Tea.Core.Models.RepositoryModels;
using Tea.Bll.Services.Abstract;

namespace Tea.Bll.Services
{
    /// <summary>
    /// this service contains app operations of appUser
    /// </summary>
    public partial class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IAppUserRepository _appUserRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUploadLocalService _uploadLocalService;
        private readonly ApiContext _apiContext;
        private readonly ISmtpService _emailService;
        private readonly ISmsNetGsmService _smsNetGsmService;
        private readonly IDataProtector _dataProtector;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly JwtSettings _jwtSettings;

        public AppUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAppUserRepository appUserRepository, IUnitOfWork unitOfWork, IUploadLocalService uploadLocalService, ApiContext apiContext, ISmtpService emailService, ISmsNetGsmService smsNetGsmService, IDataProtectionProvider dataProtectorProvider, IHttpContextAccessor httpContextAccessor, ITokenService tokenService, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appUserRepository = appUserRepository;
            _unitOfWork = unitOfWork;
            _uploadLocalService = uploadLocalService;
            _apiContext = apiContext;
            _emailService = emailService;
            _dataProtector = dataProtectorProvider.CreateProtector(nameof(AppUserService));
            _httpContextAccessor = httpContextAccessor;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
            _smsNetGsmService = smsNetGsmService;
        }
        public async Task<ResponseCommon<AppUserSignInResponseDto>> SignIn(AppUserSignInRequestDto dto)
        {
            var appUser = await _userManager.FindByEmailAsync(dto.Email);

            if (appUser is null)
                throw new ResponseException(HttpStatusCode.NotFound, ExceptionResponseType.DbNotFound, null);

            if (!await _userManager.IsEmailConfirmedAsync(appUser))
                throw new ResponseException(HttpStatusCode.BadRequest, ExceptionResponseType.AppUserSignInUnconfirmedEmail);

            if (await _userManager.IsLockedOutAsync(appUser))
                throw new ResponseException(HttpStatusCode.BadRequest, ExceptionResponseType.AppUserSignInLocked, new Exception($"Locked until {await _userManager.GetLockoutEndDateAsync(appUser)}"));

            var checkPassword = await _signInManager.CheckPasswordSignInAsync(appUser, dto.Password, true);

            if (checkPassword is { Succeeded: false })
            {
                await _userManager.AccessFailedAsync(appUser);

                throw new ResponseException(HttpStatusCode.BadRequest, ExceptionResponseType.AppUserSignInInvalidPassword);
            }

            var token = GetToken(appUser);

            await _userManager.ResetAccessFailedCountAsync(appUser);

            appUser.RefreshToken = token.RefreshToken;

            await _userManager.UpdateAsync(appUser);

            return new ResponseCommon<AppUserSignInResponseDto>
            {
                Data = new AppUserSignInResponseDto(token.AccessToken, token.AccessTokenUnixExpire, token.AccessTokenExpire, token.RefreshToken, token.RefreshTokenUnixExpire, token.RefreshTokenExpire),
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK
            };
        }

        public async Task<ResponseCommon<AppUserSignInRefreshResponseDto>> SignInRefresh(AppUserSignInRefreshRequestDto dto)
        {
            var isRefreshTokenValid = _tokenService.ValidateRefreshTokenExpire(dto.RefreshToken);

            if (!isRefreshTokenValid)
                throw new ResponseException(HttpStatusCode.BadRequest, ExceptionResponseType.AppUserSignInInvalidRefreshToken, null);

            var appUser = await _appUserRepository.GetAsync(x => x.RefreshToken == dto.RefreshToken, true);

            if (appUser is null)
                throw new ResponseException(HttpStatusCode.NotFound, ExceptionResponseType.DbNotFound, null);

            if (!await _userManager.IsEmailConfirmedAsync(appUser))
                throw new ResponseException(HttpStatusCode.BadRequest, ExceptionResponseType.AppUserSignInUnconfirmedEmail);

            if (await _userManager.IsLockedOutAsync(appUser))
                throw new ResponseException(HttpStatusCode.BadRequest, ExceptionResponseType.AppUserSignInLocked, new Exception($"Locked until {await _userManager.GetLockoutEndDateAsync(appUser)}"));

            var token = GetToken(appUser);

            return new ResponseCommon<AppUserSignInRefreshResponseDto>
            {
                Data = new AppUserSignInRefreshResponseDto(token.AccessToken, token.AccessTokenUnixExpire, token.AccessTokenExpire),
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK
            };
        }

        public async Task<ResponseCommon> SendEmailPasswordResetCode(AppUserSendEmailPasswordResetCodeRequestDto dto)
        {
            var appUser = await _userManager.FindByEmailAsync(dto.Email);

            if (appUser is null)
                throw new ResponseException(HttpStatusCode.NotFound, ExceptionResponseType.DbNotFound, null);

            var code = GeneratePasswordResetCode();

            appUser.PasswordResetCode = code;

            await _userManager.UpdateAsync(appUser);

            var result = await _emailService.SendAsync(new SmtpSendData
            {
                To = new List<string>() { appUser.Email! },
                Body = $"{code}",
                Subject = "Şifre Resetleme Kodu",
            });

            if (!result.IsSuccess)
                throw new ResponseException(HttpStatusCode.BadRequest, ExceptionResponseType.AppUserConfirmationEmailSend, result.Exception, new List<string>() { "Email gönderilemedi." });

            return new ResponseCommon();
        }

        public async Task<ResponseCommon<AppUserGetPasswordResetTokenResponseDto>> GetPasswordResetToken(AppUserGetPasswordResetTokenRequestDto dto)
        {
            var appUser = await _userManager.FindByEmailAsync(dto.Email);

            if (appUser is null)
                throw new ResponseException(HttpStatusCode.NotFound, ExceptionResponseType.DbNotFound, null);

            if (appUser.PasswordResetCode != dto.Code)
                throw new ResponseException(HttpStatusCode.BadRequest, ExceptionResponseType.AppUserGetPasswordResetInvalidCode, null);

            var token = _dataProtector.Protect(await _userManager.GeneratePasswordResetTokenAsync(appUser) + "##" + dto.Email);

            return new ResponseCommon<AppUserGetPasswordResetTokenResponseDto>
            {
                Data = new AppUserGetPasswordResetTokenResponseDto(token),
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK
            };
        }

        public async Task<ResponseCommon> PasswordReset(AppUserPasswordResetRequestDto dto)
        {
            var tokenUnprotected = string.Empty;

            try
            {
                tokenUnprotected = _dataProtector.Unprotect(dto.Token);
            }
            catch (Exception ex)
            {
                throw new ResponseException(HttpStatusCode.BadRequest, ExceptionResponseType.AppUserPasswordResetInvalidToken, ex);
            }

            var email = tokenUnprotected.Split("##")[1];
            var token = tokenUnprotected.Split("##")[0];

            var appUser = await _userManager.FindByEmailAsync(email);

            if (appUser is null)
                throw new ResponseException(HttpStatusCode.NotFound, ExceptionResponseType.DbNotFound, null);

            var result = await _userManager.ResetPasswordAsync(appUser, token, dto.Password);

            if (!result.Succeeded)
                throw new ResponseException(HttpStatusCode.BadRequest, ExceptionResponseType.AppUserConfirmationEmailInvalidToken, null, result.Errors.Select(x => x.Description).ToList());

            appUser.EmailConfirmed = true;
            appUser.PasswordResetCode = null;

            await _userManager.UpdateAsync(appUser);

            await _userManager.ResetAccessFailedCountAsync(appUser);

            await _userManager.SetLockoutEndDateAsync(appUser, null);

            return new ResponseCommon
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
            };
        }

        public async Task<ResponseCommon> ChangePassword(AppUserPasswordChangeRequestDto dto)
        {
            var appUser = await _userManager.FindByEmailAsync(dto.Email);

            if (appUser is null)
                throw new ResponseException(HttpStatusCode.NotFound, ExceptionResponseType.DbNotFound, null);

            var result = await _userManager.ChangePasswordAsync(appUser, dto.CurrentPassword, dto.NewPassword);

            if (!result.Succeeded)
                throw new ResponseException(HttpStatusCode.BadRequest, ExceptionResponseType.AppUserConfirmationEmailInvalidToken, null, result.Errors.Select(x => x.Description).ToList());

            return new ResponseCommon
            {
                IsSuccess = true,
                StatusCode = HttpStatusCode.OK,
            };
        }

        /// <summary>
        /// Get access and refresh tokens
        /// </summary>
        /// <param name="appUser"></param>
        /// <returns></returns>
        private GetTokenResponse GetToken(AppUser appUser)
        {
            return _tokenService.GetToken(new GetTokenRequest
            {
                Audience = _jwtSettings.Audience,
                Issuer = _jwtSettings.Issuer,
                SecurityAlgorithms = _jwtSettings.SecurityAlgorithms,
                SecurityKey = _jwtSettings.SecurityKey,
                AccessTokenExpirationMinutes = _jwtSettings.AccessTokenExpirationMinutes,
                RefreshTokenExpirationMinutes = _jwtSettings.RefreshTokenExpirationMinutes,
                Claims = new List<Claim> {
                    new Claim(JwtRegisteredClaimNames.Sub, appUser.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Iss, _jwtSettings.Issuer!),
                    new Claim(JwtRegisteredClaimNames.Aud, _jwtSettings.Audience!),
                    new Claim(JwtRegisteredClaimNames.Amr, "password"),
                    new Claim(JwtRegisteredClaimNames.Email, appUser.Email!),
                    new Claim(JwtRegisteredClaimNames.UniqueName, appUser.UserName!),
                    new Claim(JwtRegisteredClaimNames.Typ, "JWT"),
                    new Claim(JwtRegisteredClaimNames.GivenName, appUser.Name ?? "-"),
                    new Claim(JwtRegisteredClaimNames.FamilyName, appUser.Surname ?? "-"),
                    new Claim(JwtRegisteredClaimNames.Name, $"{appUser.Name} {appUser.Surname}")
                }
            });
        }

        /// <summary>
        /// Generate password reset code to send via email
        /// </summary>
        /// <returns></returns>
        private string GeneratePasswordResetCode()
        {
            return new Random().Next(100000, 999999).ToString();
        }
    }
}
