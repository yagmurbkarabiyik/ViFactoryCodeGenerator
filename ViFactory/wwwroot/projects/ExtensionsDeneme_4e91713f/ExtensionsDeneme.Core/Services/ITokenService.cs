using System.Security.Claims;
using ExtensionsDeneme.Core.Models.TokenModels;

namespace ExtensionsDeneme.Core.Services.TokenService
{
    public interface ITokenService
    {
        GetClientTokenResult GetClientToken(GetClientTokenRequest request);
        GetTokenResponse GetToken(GetTokenRequest request);
        ClaimsPrincipal ValidateAccessToken(ValidateTokenRequest request);
        bool ValidateRefreshTokenExpire(string refreshToken);
    }
}