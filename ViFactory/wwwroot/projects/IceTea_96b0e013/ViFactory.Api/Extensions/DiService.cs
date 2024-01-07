using System.Reflection;
using IceTea.Bll.Models;
using IceTea.Bll.Services.Common;
using IceTea.Core.Core.Services;
using IceTea.Core.Models;
using IceTea.Core.Services;
using IceTea.Core.Services.TokenService;
using IceTea.Dal.Data.Common;

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

            var bllServices = Assembly.Load("IceTea.Bll")
                .GetTypes()
                .Where(x => !string.IsNullOrEmpty(x.FullName) && x.FullName.StartsWith("IceTea.Bll.Services.Abstract."))
                .ToList();

            foreach (var type in bllServices)
            {
                services.Scan(scan => scan
                    .FromAssembliesOf(type)
                    .AddClasses(classes => classes.AssignableToAny(type))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
            }

            var dalrepositories = Assembly.Load("IceTea.Dal")
                .GetTypes()
                .Where(x => !string.IsNullOrEmpty(x.FullName) && x.FullName.StartsWith("IceTea.Dal.Data.IDalRepos."))
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
