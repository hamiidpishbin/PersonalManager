using PM.Common.Infrastructure.Logging;
using PM.Common.Presentation.Endpoints;
using PM.Common.Presentation.Exceptions;
using PM.Identity.Application;
using PM.Identity.Infrastructure;
using PM.Identity.Presentation;
using PM.Identity.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseCustomSerilog();

if (builder.Environment.IsEnvironment("Docker"))
{
	
}

// Add services to the container.
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services
	.AddApplicationServices(typeof(AssemblyReference).Assembly)
	.AddInfrastructureServices(builder.Configuration)
	.AddPresentationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.ApplyMigrations();
}

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

app.MapEndpoints();

app.MapGet("/", () => "Hello World!");

app.Run();