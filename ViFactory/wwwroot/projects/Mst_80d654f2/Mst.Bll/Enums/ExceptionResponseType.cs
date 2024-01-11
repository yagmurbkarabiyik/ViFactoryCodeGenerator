using System.Net;
using Mst.Bll.Enums;

namespace Mst.Bll.Enums
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