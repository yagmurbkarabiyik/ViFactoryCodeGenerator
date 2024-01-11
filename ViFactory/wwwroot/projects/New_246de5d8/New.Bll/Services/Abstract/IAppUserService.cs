using New.Bll.Models;
using New.Bll.Dtos.AppUserDtos;

namespace New.Bll.Services.Abstract
{
    public partial interface IAppUserService
    {
        /// <summary>
        /// SignIn on app by password
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ResponseCommon<AppUserSignInResponseDto>> SignIn(AppUserSignInRequestDto dto);

        /// <summary>
        /// SignIn on app by refreshToken
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ResponseCommon<AppUserSignInRefreshResponseDto>> SignInRefresh(AppUserSignInRefreshRequestDto dto);

        /// <summary>
        /// Password reset step1: send an email containing a reset code
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResponseCommon> SendEmailPasswordResetCode(AppUserSendEmailPasswordResetCodeRequestDto model);

        /// <summary>
        /// Password reset step2: return reset token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResponseCommon<AppUserGetPasswordResetTokenResponseDto>> GetPasswordResetToken(AppUserGetPasswordResetTokenRequestDto model);

        /// <summary>
        /// Password reset step3: execute password reset
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ResponseCommon> PasswordReset(AppUserPasswordResetRequestDto dto);

        /// <summary>
        /// Change password on app
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ResponseCommon> ChangePassword(AppUserPasswordChangeRequestDto dto);
    }
}
