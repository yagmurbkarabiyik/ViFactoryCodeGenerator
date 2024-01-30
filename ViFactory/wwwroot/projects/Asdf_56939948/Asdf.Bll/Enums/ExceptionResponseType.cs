using System.Net;
using Asdf.Bll.Enums;

namespace Asdf.Bll.Enums
{
    public enum ExceptionResponseType
    {
        InternalServer = 1,
        Validation,
        DbInsert,
        DbUpdate,
        DbDelete,
        DbNotFound,
        UnsupportedMediaType,
        AppUserConfirmationEmailSend,
        AppUserConfirmationEmailInvalidExpire,
        AppUserConfirmationEmailInvalidUrl,
        AppUserConfirmationEmailInvalidAppUser,
        AppUserConfirmationEmailAlreadyConfirmed,
        AppUserConfirmationEmailInvalidToken,
        AppUserConfirmationEmailExpiredToken,
        AppUserSignInLocked,
        AppUserSignInInvalidPassword,
        AppUserSignInUnconfirmedEmail,
        AppUserSignInInvalidRefreshToken,
        AppUserGetPasswordResetInvalidCode,
        AppUserPasswordResetInvalidToken,
    }
}