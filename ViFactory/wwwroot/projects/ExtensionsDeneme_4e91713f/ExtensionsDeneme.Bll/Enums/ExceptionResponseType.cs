using System.Net;
using ExtensionsDeneme.Bll.Enums;

namespace ExtensionsDeneme.Bll.Enums
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
        LanguageDefaultCannotBePassive,
        LanguagePassiveCannotBeAssginedAsDefault
    }
}