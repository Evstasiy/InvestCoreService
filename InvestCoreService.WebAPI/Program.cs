using InvestCoreService.API.Services;
using InvestCoreService.Application.Interfaces.Services;
using InvestCoreService.Persistence.Postgres;
using Microsoft.EntityFrameworkCore;
using InvestCoreService.Application.Interfaces.Database;
using InvestCoreService.Application.Interfaces.Auth;
using InvestCoreService.Infrastructure.Utilits;
using InvestCoreService.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using InvestCoreService.Application.Models.Mapping;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSingleton<ISecurityExchangeService, SecurityExchangeService>();
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddSingleton<IKeyGenerateService, JwtService>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),
            ValidateIssuerSigningKey = true
        };
    });


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IDbContext, AppDbConext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnectString"));
});

/*builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();*/

var app = builder.Build();
 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
