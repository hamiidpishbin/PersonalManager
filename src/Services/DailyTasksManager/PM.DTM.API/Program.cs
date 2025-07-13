using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using PM.DTM.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPresentationServices();
	
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthentication();
app.UseAuthorization();
app.Run();