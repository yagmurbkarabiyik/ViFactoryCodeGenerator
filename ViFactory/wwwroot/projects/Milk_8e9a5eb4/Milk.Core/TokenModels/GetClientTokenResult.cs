using System.Security.Claims;

namespace Milk.Core.Models.TokenModels
{
    public class GetClientTokenResult
    {
        public string AccessToken { get; set; } = null!;
        public long AccessTokenUnixExpire { get; set; }
        public DateTimeOffset AccessTokenExpire { get; set; }
    }
}