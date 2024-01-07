using System.Security.Claims;
using Milk.Core.Models.TokenModels;

namespace Milk.Core.Services.TokenService
{
    public interface ITokenService
    {
        GetClientTokenResult GetClientToken(GetClientTokenRequest request);
        GetTokenResponse GetToken(GetTokenRequest request);
        ClaimsPrincipal ValidateAccessToken(ValidateTokenRequest request);
        bool ValidateRefreshTokenExpire(string refreshToken);
    }
}