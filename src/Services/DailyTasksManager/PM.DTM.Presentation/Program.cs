using PM.Common.Presentation.Endpoints;
using PM.Common.Presentation.Exceptions;
using PM.DTM.Infrastructure;
using PM.DTM.Presentation;
using PM.DTM.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services
	.AddPresentationServices(builder.Configuration)
	.AddInfrastructureServices(builder.Configuration);
	
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

app.Run();