using PM.Common.Presentation.Endpoints;
using PM.Common.Presentation.Exceptions;
using PM.DTM.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddPresentationServices(builder.Configuration);
	
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

app.MapEndpoints();

app.Run();