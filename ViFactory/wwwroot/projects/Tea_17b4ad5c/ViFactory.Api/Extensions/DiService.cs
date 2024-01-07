using System.Reflection;
using Tea.Bll.Models;
using Tea.Bll.Services.Common;
using Tea.Core.Core.Services;
using Tea.Core.Models;
using Tea.Core.Services;
using Tea.Core.Services.TokenService;
using Tea.Dal.Data.Common;

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

            var bllServices = Assembly.Load("Tea.Bll")
                .GetTypes()
                .Where(x => !string.IsNullOrEmpty(x.FullName) && x.FullName.StartsWith("Tea.Bll.Services.Abstract."))
                .ToList();

            foreach (var type in bllServices)
            {
                services.Scan(scan => scan
                    .FromAssembliesOf(type)
                    .AddClasses(classes => classes.AssignableToAny(type))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
            }

            var dalrepositories = Assembly.Load("Tea.Dal")
                .GetTypes()
                .Where(x => !string.IsNullOrEmpty(x.FullName) && x.FullName.StartsWith("Tea.Dal.Data.IDalRepos."))
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
