using System.Security.Claims;
using Artyfy.Core.Models.TokenModels;

namespace Artyfy.Core.Services.TokenService
{
    public interface ITokenService
    {
        GetClientTokenResult GetClientToken(GetClientTokenRequest request);
        GetTokenResponse GetToken(GetTokenRequest request);
        ClaimsPrincipal ValidateAccessToken(ValidateTokenRequest request);
        bool ValidateRefreshTokenExpire(string refreshToken);
    }
}