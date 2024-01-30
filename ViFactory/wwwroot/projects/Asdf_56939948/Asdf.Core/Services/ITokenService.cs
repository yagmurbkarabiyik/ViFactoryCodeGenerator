using System.Security.Claims;
using Asdf.Core.Models.TokenModels;

namespace Asdf.Core.Services.TokenService
{
   public interface ITokenService
    {
        GetTokenResponse GetToken(GetTokenRequest request);
        ClaimsPrincipal ValidateAccessToken(ValidateTokenRequest request);
        bool ValidateRefreshTokenExpire(string refreshToken);
    }
}