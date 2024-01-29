using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tea.Bll.Enums;
using Tea.Bll.Models;

namespace ViFactory.Api.Config
{
    public static class ApiBehaviourConfig
    {
        public static void ConfigureCustomValidationModel(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = false;

                opt.InvalidModelStateResponseFactory = context =>
                {                  
                    var modelState = context.ModelState;

                    var response = new ResponseCommon<ResponseExceptionData>
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        IsSuccess = false,
                        Data = new ResponseExceptionData()
                        {
                            Type = ExceptionResponseType.Validation,
                            Errors = modelState.Values.SelectMany(v => v.Errors)
                                .Select(e => e.ErrorMessage)
                                .ToList(),
                            ValidationErrors = modelState.Where(x => x is { Value: not null, Value.Errors: not null }).ToDictionary(x => x.Key, x => x.Value?.Errors.Select(x => x.ErrorMessage).ToList())
                        }
                    };

                    var result = new ObjectResult(response)
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                    };

                    result.ContentTypes.Add("application/json");

                    return result;
                };
            });
        }
    }
}
