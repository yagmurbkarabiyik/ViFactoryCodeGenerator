using Microsoft.CodeAnalysis.Options;
using Microsoft.OpenApi.Models;
using Coffee.Middlewares;
using ViFactory.Api.Config;
using ViFactory.Api.Extensions;
using ViFactory.Api.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers(opt =>
    {
        opt.ModelValidatorProviders.Clear();
    })
    .AddNewtonsoftJson(config =>
    {
        config.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
        config.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    config.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });

});

builder.Services.AddResponseCompression();
builder.Services.AddMemoryCache();
builder.Services.AddDataProtection();

builder.Services.AddCustomDbContext(builder.Configuration);
builder.Services.AddCustomDiServices(builder.Environment, builder.Configuration);
builder.Services.AddCustomFluentValidator();
builder.Services.ConfigureCustomValidationModel();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<CustomExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
