using Microsoft.AspNetCore.Mvc;
using IceTea.Bll.Models;
using IceTea.Bll.Services.Abstract;
using IceTea.Bll.Dtos.AppUserDtos;

namespace ViFactory.Api.Controllers
{
    [Area("MobileServices")]
    [Route("app-api/[controller]")]
    [ApiController]
    public class AppUsersController : Controller
    {
        private readonly IAppUserService _appUserService;

        public AppUsersController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpPost("signin")]
        [ProducesResponseType(200, Type = typeof(ResponseCommon<AppUserSignInResponseDto?>))]
        [ProducesResponseType(400, Type = typeof(ResponseCommon<ResponseExceptionData>))]
        [ProducesResponseType(404, Type = typeof(ResponseCommon<ResponseExceptionData>))]
        [ProducesResponseType(500, Type = typeof(ResponseCommon<ResponseExceptionData>))]
        public async Task<IActionResult> SignIn([FromBody] AppUserSignInRequestDto dto)
        {
            var response = await _appUserService.SignIn(dto);

            return new ObjectResult(response)
            {
                StatusCode = (int)response.StatusCode
            };
        }

        [HttpGet("signinrefresh")]
        [ProducesResponseType(200, Type = typeof(ResponseCommon<AppUserSignInRefreshResponseDto?>))]
        [ProducesResponseType(400, Type = typeof(ResponseCommon<ResponseExceptionData>))]
        [ProducesResponseType(404, Type = typeof(ResponseCommon<ResponseExceptionData>))]
        [ProducesResponseType(500, Type = typeof(ResponseCommon<ResponseExceptionData>))]
        public async Task<IActionResult> SignInRefresh([FromQuery] AppUserSignInRefreshRequestDto dto)
        {
            var response = await _appUserService.SignInRefresh(dto);

            return new ObjectResult(response)
            {
                StatusCode = (int)response.StatusCode
            };
        }

        [HttpGet("sendemailpasswordresetcode")]
        [ProducesResponseType(200, Type = typeof(ResponseCommon))]
        [ProducesResponseType(400, Type = typeof(ResponseCommon<ResponseExceptionData>))]
        [ProducesResponseType(404, Type = typeof(ResponseCommon<ResponseExceptionData>))]
        [ProducesResponseType(500, Type = typeof(ResponseCommon<ResponseExceptionData>))]
        public async Task<IActionResult> SendEmailPasswordResetCode([FromQuery] AppUserSendEmailPasswordResetCodeRequestDto dto)
        {
            var response = await _appUserService.SendEmailPasswordResetCode(dto);

            return new ObjectResult(response)
            {
                StatusCode = (int)response.StatusCode
            };
        }

        [HttpGet("getpasswordresettoken")]
        [ProducesResponseType(200, Type = typeof(ResponseCommon<AppUserGetPasswordResetTokenResponseDto>))]
        [ProducesResponseType(400, Type = typeof(ResponseCommon<ResponseExceptionData>))]
        [ProducesResponseType(404, Type = typeof(ResponseCommon<ResponseExceptionData>))]
        [ProducesResponseType(500, Type = typeof(ResponseCommon<ResponseExceptionData>))]
        public async Task<IActionResult> GetPasswordResetToken([FromQuery] AppUserGetPasswordResetTokenRequestDto dto)
        {
            var response = await _appUserService.GetPasswordResetToken(dto);

            return new ObjectResult(response)
            {
                StatusCode = (int)response.StatusCode
            };
        }

        [HttpPost("passwordreset")]
        [ProducesResponseType(200, Type = typeof(ResponseCommon))]
        [ProducesResponseType(400, Type = typeof(ResponseCommon<ResponseExceptionData>))]
        [ProducesResponseType(404, Type = typeof(ResponseCommon<ResponseExceptionData>))]
        [ProducesResponseType(500, Type = typeof(ResponseCommon<ResponseExceptionData>))]
        public async Task<IActionResult> PasswordReset([FromBody] AppUserPasswordResetRequestDto dto)
        {
            var response = await _appUserService.PasswordReset(dto);

            return new ObjectResult(response)
            {
                StatusCode = (int)response.StatusCode
            };
        }

        [HttpPost("changepassword")]
        [ProducesResponseType(200, Type = typeof(ResponseCommon))]
        [ProducesResponseType(400, Type = typeof(ResponseCommon<ResponseExceptionData>))]
        [ProducesResponseType(404, Type = typeof(ResponseCommon<ResponseExceptionData>))]
        [ProducesResponseType(500, Type = typeof(ResponseCommon<ResponseExceptionData>))]
        public async Task<IActionResult> PasswordChange([FromBody] AppUserPasswordChangeRequestDto dto)
        {
            var response = await _appUserService.ChangePassword(dto);

            return new ObjectResult(response)
            {
                StatusCode = (int)response.StatusCode
            };
        }
    }
}
