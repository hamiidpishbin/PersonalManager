using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(o =>
	{
		o.RequireHttpsMetadata = false;
		o.Audience = builder.Configuration["Authentication:Audience"];
		o.MetadataAddress = builder.Configuration["Authentication:MetadataAddress"]!;
		o.TokenValidationParameters = new TokenValidationParameters
		{
			ValidIssuer = builder.Configuration["Authentication:ValidIssuer"],
		};
	});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthentication();
app.UseAuthorization();

app.Run();