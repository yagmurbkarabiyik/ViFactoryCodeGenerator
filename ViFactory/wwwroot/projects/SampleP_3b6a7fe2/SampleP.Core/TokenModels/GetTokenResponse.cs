    
namespace SampleP.Core.Models.TokenModels
{
    public class GetTokenResponse
    {
        public string AccessToken { get; set; } = null!;
        public long AccessTokenUnixExpire { get; set; }
        public DateTimeOffset AccessTokenExpire { get; set; }
        public string RefreshToken { get; set; } = null!;
        public long RefreshTokenUnixExpire { get; set; }
        public DateTimeOffset RefreshTokenExpire { get; set; }
    }
}