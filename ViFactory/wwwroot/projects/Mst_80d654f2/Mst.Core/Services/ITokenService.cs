using System.Security.Claims;
using Mst.Core.Models.TokenModels;

namespace Mst.Core.Services.TokenService
{
   public interface ITokenService
    {
        GetTokenResponse GetToken(GetTokenRequest request);
        ClaimsPrincipal ValidateAccessToken(ValidateTokenRequest request);
        bool ValidateRefreshTokenExpire(string refreshToken);
    }
}