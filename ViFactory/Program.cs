using ViFactory.Services.Api;
using ViFactory.Services.Bll;
using ViFactory.Services.Console;
using ViFactory.Services.Core;
using ViFactory.Services.Dal;
using ViFactory.Services.Domain;
using ViFactory.Services.Dtos;
using ViFactory.Services.Generators;
using ViFactory.Services.Project;
using ViFactory.Services.Solution;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddScoped<IGenerator, Generator>();
builder.Services.AddScoped<ICoreGenerator, CoreGenerator>();
builder.Services.AddScoped<IDomainGenerator, DomainGenerator>();
builder.Services.AddScoped<IDtoGenerator, DtoGenerator>();
builder.Services.AddScoped<IDalGenerator,DalGenerator>();	
builder.Services.AddScoped<IBllGenerator, BllGenerator>();
builder.Services.AddScoped<ISolutionGenerator, SolutionGenertor>();	
builder.Services.AddScoped<IProjectGenerator, ProjectGenerator>();
builder.Services.AddScoped<IConsoleGenerator, ConsoleGenerator>();	
builder.Services.AddScoped<IApiGenerator, ApiGenerator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
