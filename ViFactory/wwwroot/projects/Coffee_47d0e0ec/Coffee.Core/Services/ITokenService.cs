using System.Security.Claims;
using Coffee.Core.Models.TokenModels;

namespace Coffee.Core.Services.TokenService
{
    public interface ITokenService
    {
        GetClientTokenResult GetClientToken(GetClientTokenRequest request);
        GetTokenResponse GetToken(GetTokenRequest request);
        ClaimsPrincipal ValidateAccessToken(ValidateTokenRequest request);
        bool ValidateRefreshTokenExpire(string refreshToken);
    }
}