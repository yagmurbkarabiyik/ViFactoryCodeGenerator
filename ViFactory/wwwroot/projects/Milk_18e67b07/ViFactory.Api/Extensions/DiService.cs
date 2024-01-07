using System.Reflection;
using Milk.Bll.Models;
using Milk.Bll.Services.Common;
using Milk.Core.Core.Services;
using Milk.Core.Models;
using Milk.Core.Services;
using Milk.Core.Services.TokenService;
using Milk.Dal.Data.Common;

namespace ViFactory.Api.Extentions
{
    public static class DiServices
    {
        public static void AddCustomDiServices(this IServiceCollection services, IWebHostEnvironment env, IConfiguration config)
        {
            services.Configure<JwtSettings>(config.GetSection(nameof(JwtSettings)));
            services.Configure<EmailSettings>(config.GetSection(nameof(EmailSettings)));
            services.Configure<SmsNetGsmSettings>(config.GetSection(nameof(SmsNetGsmSettings)));

            services.AddScoped<IUploadLocalService, UploadLocalService>(x =>
            {
                return new UploadLocalService(Path.Combine(env.WebRootPath, "uploads", "public"), Path.Combine(env.WebRootPath, "uploads", "private"));
            });
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ISmsNetGsmService, SmsNetGsmService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ApiContext>();

            var bllServices = Assembly.Load("Milk.Bll")
                .GetTypes()
                .Where(x => !string.IsNullOrEmpty(x.FullName) && x.FullName.StartsWith("Milk.Bll.Services.Abstract."))
                .ToList();

            foreach (var type in bllServices)
            {
                services.Scan(scan => scan
                    .FromAssembliesOf(type)
                    .AddClasses(classes => classes.AssignableToAny(type))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
            }

            var dalrepositories = Assembly.Load("Milk.Dal")
                .GetTypes()
                .Where(x => !string.IsNullOrEmpty(x.FullName) && x.FullName.StartsWith("Milk.Dal.Data.IDalRepos."))
                .ToList();

            foreach (var type in dalrepositories)
            {
                services.Scan(scan => scan
                    .FromAssembliesOf(type)
                    .AddClasses(classes => classes.AssignableToAny(type))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
            }
        }
    }
}
