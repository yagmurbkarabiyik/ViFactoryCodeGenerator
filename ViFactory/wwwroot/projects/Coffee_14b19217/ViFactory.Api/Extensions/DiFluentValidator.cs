using FluentValidation;
using FluentValidation.AspNetCore;

namespace Coffee.Extentions
{
    public static class DiFluentValidator
    {
        public static void AddCustomFluentValidator(this IServiceCollection services)
        {
             //services.AddFluentValidation(fv =>
             //{
            //   fv.RegisterValidatorsFromAssemblyContaining(typeof(Domain.Dtos.CompanyDtos.CompanyCreateRequestValidator));
           // });

            ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;
        }
    }
}
