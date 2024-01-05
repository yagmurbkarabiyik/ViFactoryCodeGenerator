using System.Security.Claims;

namespace ExtensionsDeneme.Core.Models.TokenModels
{
    public class GetTokenRequest
    {
        public string SecurityKey { get; set; } = null!;
        public int AccessTokenExpirationMinutes { get; set; }
        public int RefreshTokenExpirationMinutes { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
        public string SecurityAlgorithms { get; set; } = Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature;
        public List<Claim>? Claims { get; set; }
    }
}