using Microsoft.IdentityModel.Tokens;

namespace Neeww.Core.Models.TokenModels
{
    public class ValidateTokenRequest
    {
        public string AccessToken { get; set; } = null!;
        public TokenValidationParameters TokenValidationParameters { get; set; } = null!;
    }
}