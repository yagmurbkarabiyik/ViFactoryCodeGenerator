using Ybk.Core.Enums;

namespace Ybk.Bll.Dtos.AppUserDtos
{
    public record AppUserSignInResponseDto(string AccessToken, long AccessTokenUnixExpire, DateTimeOffset AccessTokenExpire, string RefreshToken, long RefreshTokenUnixExpire, DateTimeOffset RefreshTokenExpire);

    public record AppUserSignInRefreshResponseDto(string AccessToken, long AccessTokenUnixExpire, DateTimeOffset AccessTokenExpire);

    public record AppUserGetPasswordResetTokenResponseDto(string Token);
}
