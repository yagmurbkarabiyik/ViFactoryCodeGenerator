using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using New.Core.Models.TokenModels;
using New.Core.Services.TokenService;

namespace New.Bll.Services.Common
{
    public class TokenService  : ITokenService
    {
        private readonly IDataProtector _dataProtector;

        public TokenService(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtector = dataProtectionProvider.CreateProtector(nameof(TokenService));
        }

        public GetTokenResponse GetToken(GetTokenRequest request)
        {
            var jwtSecurityToken = GetJwtSecurityToken(request);

            var refreshTokenExpire = DateTimeOffset.UtcNow.AddMinutes(request.RefreshTokenExpirationMinutes);

            return new GetTokenResponse
            {
                AccessToken = GetAccessToken(jwtSecurityToken),
                AccessTokenUnixExpire = new DateTimeOffset(jwtSecurityToken.ValidTo, TimeSpan.Zero).ToUnixTimeSeconds(),
                AccessTokenExpire = jwtSecurityToken.ValidTo,
                RefreshToken = GetRefreshToken(refreshTokenExpire),
                RefreshTokenUnixExpire = refreshTokenExpire.ToUnixTimeSeconds(),
                RefreshTokenExpire = refreshTokenExpire
            };
        }

        public ClaimsPrincipal ValidateAccessToken(ValidateTokenRequest request)
        {
            var handler = new JwtSecurityTokenHandler();

            SecurityToken validatedToken;

            return handler.ValidateToken(request.AccessToken, request.TokenValidationParameters, out validatedToken);
        }

        public bool ValidateRefreshTokenExpire(string refreshToken)
        {
            try
            {
                var token = _dataProtector.Unprotect(refreshToken);

                var expire = token.Split("##")[1];

                var date = DateTimeOffset.FromUnixTimeSeconds(Int64.Parse(expire));

                return date > DateTimeOffset.UtcNow;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private JwtSecurityToken GetJwtSecurityToken(GetTokenRequest request)
        {
            var accessTokenExpire = DateTimeOffset.Now.AddMinutes(request.AccessTokenExpirationMinutes);
            var now = DateTimeOffset.Now;

            request.Claims = request.Claims ?? new List<Claim>();

            request.Claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, now.ToString()));
            request.Claims.Add(new Claim(JwtRegisteredClaimNames.Exp, accessTokenExpire.ToString()));
            request.Claims.Add(new Claim(JwtRegisteredClaimNames.Iat, now.ToString()));
            request.Claims.Add(new Claim(JwtRegisteredClaimNames.AuthTime, now.ToString()));
            request.Claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            return new JwtSecurityToken(
                issuer: request.Issuer,
                expires: accessTokenExpire.DateTime,
                notBefore: now.DateTime,
                claims: request.Claims,
                signingCredentials: GetSigningCredentials(request.SecurityKey, request.SecurityAlgorithms),
                audience: request.Audience
            );
        }

        private SigningCredentials GetSigningCredentials(string key, string algorithm)
        {
            return new SigningCredentials(GetSecurityKey(key), algorithm);
        }

        private SecurityKey GetSecurityKey(string key)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }

        private string GetAccessToken(JwtSecurityToken jwtSecurityToken)
        {
            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(jwtSecurityToken);
        }

        private string GetRefreshToken(DateTimeOffset expire)
        {
            var numberByte = new Byte[32];

            var rnd = RandomNumberGenerator.Create();

            rnd.GetBytes(numberByte);

            var refreshtoken = Convert.ToBase64String(numberByte) + "##" + expire.ToUnixTimeSeconds().ToString();

            return _dataProtector.Protect(refreshtoken);
        }
    }
}