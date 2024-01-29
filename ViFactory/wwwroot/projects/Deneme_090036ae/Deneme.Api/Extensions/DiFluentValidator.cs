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
               fv.RegisterValidatorsFromAssemblyContaining(typeof(Deneme.Bll.Dtos.AppUserDtos.AppUserCreateRequestValidator));
             });

            ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;
        }
    }
}