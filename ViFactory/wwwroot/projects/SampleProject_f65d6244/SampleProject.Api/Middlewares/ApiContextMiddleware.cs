using System.Security.Claims;
using SampleProject.Core.Models;
using System.IdentityModel.Tokens.Jwt;

namespace SampleProject.Api.Middlewares
{
    public class ApiContextMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, ApiContext apiContext)
        {
            var userIdClaim = context.User.Claims?.Where(c => c.Type == JwtRegisteredClaimNames.Sub || c.Type == ClaimTypes.NameIdentifier)?.FirstOrDefault();
            if (userIdClaim != null)
                apiContext.AppUserId = Convert.ToInt32(userIdClaim.Value);

            var userFullNameClaim = context.User.Claims?.Where(c => c.Type == JwtRegisteredClaimNames.Name || c.Type == ClaimTypes.Name)?.FirstOrDefault();
            if (userFullNameClaim != null)
                apiContext.AppUserFullName = userFullNameClaim.Value;

            var userNameClaim = context.User.Claims?.Where(c => c.Type == JwtRegisteredClaimNames.GivenName || c.Type == ClaimTypes.GivenName)?.FirstOrDefault();
            if (userNameClaim != null)
                apiContext.AppUserName = userNameClaim.Value;

            var userEmailClaim = context.User.Claims?.Where(c => c.Type == JwtRegisteredClaimNames.Email || c.Type == ClaimTypes.Email)?.FirstOrDefault();
            if (userEmailClaim != null)
                apiContext.Email = userEmailClaim.Value;

            var subscriptionIdClaim = context.User.Claims?.Where(c => c.Type == "subscription_id")?.FirstOrDefault();
            if (subscriptionIdClaim != null)
                apiContext.SubscriptionId = subscriptionIdClaim.Value;

            var signInRemoteClaim = context.User.Claims?.Where(c => c.Type == "remote_ip")?.FirstOrDefault();
            if (signInRemoteClaim != null)
                apiContext.SignInRemoteIp = signInRemoteClaim.Value;

            var clientType = context.Request.Headers["X-Client-Type"];
            if (!string.IsNullOrEmpty(clientType) && clientType.Count > 0)
                apiContext.ClientType = clientType.FirstOrDefault() ?? "other";
            else
                apiContext.ClientType = "web";

            apiContext.CurrentRemoteIp = context.Connection.RemoteIpAddress?.ToString();

            await _next(context);
        }
    }
}