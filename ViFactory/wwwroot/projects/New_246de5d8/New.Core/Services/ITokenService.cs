using System.Security.Claims;
using New.Core.Models.TokenModels;

namespace New.Core.Services.TokenService
{
   public interface ITokenService
    {
        GetTokenResponse GetToken(GetTokenRequest request);
        ClaimsPrincipal ValidateAccessToken(ValidateTokenRequest request);
        bool ValidateRefreshTokenExpire(string refreshToken);
    }
}