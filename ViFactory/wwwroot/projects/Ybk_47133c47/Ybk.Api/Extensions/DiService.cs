using System.Reflection;
using Ybk.Bll.Models;
using Ybk.Bll.Services.Common;
using Ybk.Core.Services;
using Ybk.Core.Models;
using Ybk.Core.Services.TokenService;
using Ybk.Dal.Data.Common;

namespace ViFactory.Api.Extentions
{
    public static class DiServices
    {
        public static void AddCustomDiServices(this IServiceCollection services, IWebHostEnvironment env, IConfiguration config)
        {
            services.Configure<JwtSettings>(config.GetSection(nameof(JwtSettings)));
            services.Configure<SmtpSettings>(config.GetSection(nameof(SmtpSettings)));
            services.Configure<SmsNetGsmSettings>(config.GetSection(nameof(SmsNetGsmSettings)));

            services.AddScoped<IUploadLocalService, UploadLocalService>(x =>
            {
                return new UploadLocalService(Path.Combine(env.WebRootPath, "uploads", "public"), Path.Combine(env.WebRootPath, "uploads", "private"));
            });
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ISmtpService, SmtpService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISmsNetGsmService, SmsNetGsmService>();
            services.AddScoped<ApiContext>();

            var bllServices = Assembly.Load("Ybk.Bll")
                .GetTypes()
                .Where(x => !string.IsNullOrEmpty(x.FullName) && x.FullName.StartsWith("Ybk.Bll.Services.Abstract."))
                .ToList();

            foreach (var type in bllServices)
            {
                services.Scan(scan => scan
                    .FromAssembliesOf(type)
                    .AddClasses(classes => classes.AssignableToAny(type))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
            }

            var dalrepositories = Assembly.Load("Ybk.Dal")
                .GetTypes()
                .Where(x => !string.IsNullOrEmpty(x.FullName) && x.FullName.StartsWith("Ybk.Dal.Data.IDalRepos."))
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