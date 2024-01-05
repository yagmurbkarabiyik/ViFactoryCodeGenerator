using System.Security.Claims;
using Extensions.Core.Models.TokenModels;

namespace Extensions.Core.Services.TokenService
{
    public interface ITokenService
    {
        GetClientTokenResult GetClientToken(GetClientTokenRequest request);
        GetTokenResponse GetToken(GetTokenRequest request);
        ClaimsPrincipal ValidateAccessToken(ValidateTokenRequest request);
        bool ValidateRefreshTokenExpire(string refreshToken);
    }
}