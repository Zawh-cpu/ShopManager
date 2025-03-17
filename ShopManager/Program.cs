using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using ShopManager.Core.Entities;
using ShopManager.Infrastructure.Data;
using ShopManager.Core.Interfaces;
using ShopManager.Infrastructure.Data.Config;
using ShopManager.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

var authConfigRaw = builder.Configuration.GetSection("AuthConfig");
builder.Services.Configure<AuthConfig>(authConfigRaw);

var authConfig = authConfigRaw.Get<AuthConfig>()!;

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.UseSecurityTokenValidators = true;
    
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = authConfig.JwtIssuer,
        ValidAudience = authConfig.JwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(authConfig.SecretKey)
    };
    
    options.Events = new JwtBearerEvents
    {
        OnTokenValidated = async context =>
        {
            var token = context.SecurityToken as System.IdentityModel.Tokens.Jwt.JwtSecurityToken;
            if (token == null)
            {
                context.Fail("Invalid token.");
                return;
            }

            var serviceScopeFactory = context.HttpContext.RequestServices.GetRequiredService<IServiceScopeFactory>();
    
            using var scope = serviceScopeFactory.CreateScope();
            var tokenService = scope.ServiceProvider.GetRequiredService<ITokenService>();

            if (!Guid.TryParse(token.Id, out Guid tokenId))
            {
                context.Fail("Invalid token.");
                return;
            }

            var tokenStatus = await tokenService.GetTokenByIdAsync(tokenId);
            if (tokenStatus == null || tokenStatus.IsRevoked)
            {
                context.Fail("Revoked token.");
                return;
            }

            if (tokenStatus.TokenType == TokenType.Refresh && context.HttpContext.Request.Path != "/api/auth/refresh")
            {
                context.Fail("You cannot use refresh token to do actions.");
            }
        }
    };
});


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString), ServiceLifetime.Scoped);
builder.Services.AddSingleton<IJwtService, JwtService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // ARE ABLE TO ADD SWAGGER
    app.MapOpenApi();
    app.UseReDoc(options => options.SpecUrl("/openapi/v1.json"));
    app.MapScalarApiReference();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();