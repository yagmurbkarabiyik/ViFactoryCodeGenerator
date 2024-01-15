using Newtonsoft.Json;
using System.Net;
using Artyfy.Bll.Enums;
using Artyfy.Bll.Models;

namespace ViFactory.Api.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JsonSerializerSettings _settings;
        private readonly ILogger<CustomExceptionMiddleware> _logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
        {
            _next = next;
            _settings = new JsonSerializerSettings();
            _settings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            _settings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ResponseException ex)
            {
                await HandleResponseExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleResponseExceptionAsync(HttpContext context, ResponseException ex)
        {
            var response = new ResponseCommon<ResponseExceptionData>
            {
                StatusCode = ex.StatusCode,
                IsSuccess = false,
                Data = new ResponseExceptionData()
                {
                    Errors = ex.Errors,
                    Type = ex.Type,
                }
            };
            
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)ex.StatusCode;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, _settings));  
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var response = new ResponseCommon<ResponseExceptionData>
            {
                StatusCode = HttpStatusCode.InternalServerError,
                IsSuccess = false,
                Data = new ResponseExceptionData()
                {
                    Errors = new List<string>() { ex.Message },
                    Type = ExceptionResponseType.InternalServer
                }
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, _settings));       
        }
    }
}
