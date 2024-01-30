using Microsoft.IdentityModel.Tokens;

namespace dddd.Core.Models.TokenModels
{
    public class ValidateTokenRequest
    {
        public string AccessToken { get; set; } = null!;
        public TokenValidationParameters TokenValidationParameters { get; set; } = null!;
    }
}