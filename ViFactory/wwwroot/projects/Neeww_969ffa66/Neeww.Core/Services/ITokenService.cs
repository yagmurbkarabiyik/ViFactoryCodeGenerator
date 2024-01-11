using System.Security.Claims;
using Neeww.Core.Models.TokenModels;

namespace Neeww.Core.Services.TokenService
{
   public interface ITokenService
    {
        GetTokenResponse GetToken(GetTokenRequest request);
        ClaimsPrincipal ValidateAccessToken(ValidateTokenRequest request);
        bool ValidateRefreshTokenExpire(string refreshToken);
    }
}