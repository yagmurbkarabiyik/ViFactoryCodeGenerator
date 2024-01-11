using FluentValidation;
using FluentValidation.AspNetCore;

namespace ViFactory.Api.Extensions
{
    public static class DiFluentValidator
    {
        public static void AddCustomFluentValidator(this IServiceCollection services)
        {
            services.AddFluentValidation(fv =>
             {
               fv.RegisterValidatorsFromAssemblyContaining(typeof(aws.Bll.Dtos.AppUserDtos.AppUserCreateRequestValidator));
             });

            ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;
        }
    }
}
