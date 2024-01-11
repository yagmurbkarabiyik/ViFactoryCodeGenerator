using System.Reflection;
using aws.Bll.Models;
using aws.Bll.Services.Common;
using aws.Core.Services;
using aws.Core.Models;
using aws.Core.Services.TokenService;
using aws.Dal.Data.Common;

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
            services.AddScoped<ApiContext>();

            var bllServices = Assembly.Load("aws.Bll")
                .GetTypes()
                .Where(x => !string.IsNullOrEmpty(x.FullName) && x.FullName.StartsWith("aws.Bll.Services.Abstract."))
                .ToList();

            foreach (var type in bllServices)
            {
                services.Scan(scan => scan
                    .FromAssembliesOf(type)
                    .AddClasses(classes => classes.AssignableToAny(type))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
            }

            var dalrepositories = Assembly.Load("aws.Dal")
                .GetTypes()
                .Where(x => !string.IsNullOrEmpty(x.FullName) && x.FullName.StartsWith("aws.Dal.Data.IDalRepos."))
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
