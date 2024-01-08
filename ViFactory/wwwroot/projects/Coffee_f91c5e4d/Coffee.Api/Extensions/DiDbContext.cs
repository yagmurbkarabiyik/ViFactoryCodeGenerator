using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.Text;
using Coffee.Dal.Context;
using Coffee.Domain.IdentityModels;

namespace ViFactory.Api.Extentions
{
    public static class DiDbContext
    {
        public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CoffeeDbContext>(x =>
            {
                x.UseNpgsql(configuration.GetConnectionString("PostreSql"), config =>
                {
                    config.MigrationsAssembly("CoffeeDbContext.Dal");
                });
            });

            services.AddIdentity<AppUser, AppRole>(actions =>
            {
                // password
                actions.Password.RequiredLength = 8;
                actions.Password.RequireDigit = true;
                actions.Password.RequireUppercase = true;
                actions.Password.RequireLowercase = true;
                actions.Password.RequireNonAlphanumeric = false;
                actions.Password.RequiredUniqueChars = 1;

                // user
                actions.User.RequireUniqueEmail = true;

                //lockout
                actions.Lockout.MaxFailedAccessAttempts = 5;
                actions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(15);

                // signin
                actions.SignIn.RequireConfirmedEmail = true;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<CoffeeDbContext>();

            const string AuthSchemaName = "CustomAuthSchema";
            const string CookieName = "vis_token";

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = AuthSchemaName;
                options.DefaultSignInScheme = AuthSchemaName;
                options.DefaultChallengeScheme = AuthSchemaName;
            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.Cookie.Name = CookieName;
                options.Cookie.MaxAge = TimeSpan.FromHours(24);
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.SlidingExpiration = true;
                options.AccessDeniedPath = "/auth/signup";
                options.LoginPath = "/auth/signin";
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "your_issuer",
                    ValidAudience = "your_audience",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key"))
                };
            }).AddPolicyScheme(AuthSchemaName, AuthSchemaName, options =>
            {
                options.ForwardDefaultSelector = context =>
                {
                    string? authorization = context.Request.Headers != null ? context.Request.Headers[HeaderNames.Authorization] : default;

                    if (!string.IsNullOrEmpty(authorization) && authorization.StartsWith("Bearer "))
                        return JwtBearerDefaults.AuthenticationScheme;

                    return CookieAuthenticationDefaults.AuthenticationScheme;
                };
            });
        }
    }
}