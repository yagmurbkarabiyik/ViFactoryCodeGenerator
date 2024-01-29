using System.Security.Claims;
using SampleProject.Core.Models.TokenModels;

namespace SampleProject.Core.Services.TokenService
{
   public interface ITokenService
    {
        GetTokenResponse GetToken(GetTokenRequest request);
        ClaimsPrincipal ValidateAccessToken(ValidateTokenRequest request);
        bool ValidateRefreshTokenExpire(string refreshToken);
    }
}