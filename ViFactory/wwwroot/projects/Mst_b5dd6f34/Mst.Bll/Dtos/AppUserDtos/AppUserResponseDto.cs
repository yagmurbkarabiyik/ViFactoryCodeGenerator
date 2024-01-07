using Mst.Core.Enums;

namespace Mst.Bll.Dtos.AppUserDtos
{
    public record AppUserTableResponseDto(int Id, string Name, string Surname, string Email, bool EmailConfirmed, string? DefaultPosterImage, int? DepartmentId, string? DepartmentDefaultTitle, int CompanyId, string CompanyDefaultTitle, DbEntityState State);

    public record AppUserListSelectItemsResponseDto(int Id, string DefaultTitle, string? DefaultPosterImage, int? DepartmentId, string? DepartmentDefaultTitle, DbEntityState State);

    public record AppUserSignInResponseDto(string AccessToken, long AccessTokenUnixExpire, DateTimeOffset AccessTokenExpire, string RefreshToken, long RefreshTokenUnixExpire, DateTimeOffset RefreshTokenExpire);

    public record AppUserSignInRefreshResponseDto(string AccessToken, long AccessTokenUnixExpire, DateTimeOffset AccessTokenExpire);

    public record AppUserGetPasswordResetTokenResponseDto(string Token);
}
