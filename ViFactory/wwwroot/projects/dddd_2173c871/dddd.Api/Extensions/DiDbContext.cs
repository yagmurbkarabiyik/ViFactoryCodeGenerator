using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.Text;
using dddd.Dal.Context;
using dddd.Domain.IdentityModels;

namespace ViFactory.Api.Extentions
{
    public static class DiDbContext
    {
        public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ddddDbContext>(x =>
            {
                x.UseNpgsql(configuration.GetConnectionString("PostreSql"), config =>
                {
                    config.MigrationsAssembly("dddd.Dal");
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
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<ddddDbContext>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecurityKey"]!))
                };
            });
        }
    }
}