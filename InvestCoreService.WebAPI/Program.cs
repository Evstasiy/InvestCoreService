using InvestCoreService.API.Services;
using InvestCoreService.Application.Interfaces.Services;
using InvestCoreService.Persistence.Postgres;
using Microsoft.EntityFrameworkCore;
using InvestCoreService.Infrastructure.Utilits;
using InvestCoreService.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using InvestCoreService.Application.Models.Mapping;
using AutoMapper;
using Microsoft.OpenApi.Models;
using InvestCoreService.Domain.Models.Interfaces.Auth;
using InvestCoreService.Domain.Models.Interfaces.Services;
using InvestCoreService.Domain.Models.BaseModels;
using InvestCoreService.Domain.Models.Interfaces.Database;
using InvestCoreService.Infrastructure.Database.BufferDb;
using InvestCoreService.API.Handlers;
using InvestCoreService.Domain.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using InvestCoreService.Domain.Models.Interfaces;
using InvestBroker.SmulationAPI;
using InvestBroker.FinamAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile<MappingProfile>();
}).CreateMapper());

builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddSingleton<IKeyGenerateService, JwtService>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();

//builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<User>, UserTextRepository>();
builder.Services.AddSingleton<IBaseBroker, SimulationCore>();
//builder.Services.AddSingleton<IBaseBroker, FinamCore>();

builder.Services.AddSingleton<ISecurityExchangeService, SecurityExchangeService>();

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

builder.Services.AddAuthorization(options =>
{
    foreach (AccessLevel level in Enum.GetValues(typeof(AccessLevel)))
    {
        int value = (int)level;
        string policyName = level.ToString();

        options.AddPolicy(policyName, policy =>
        {
            policy.Requirements.Add(new AccessLevelRequirement(value));
        });
    }
});
builder.Services.AddSingleton<IAuthorizationHandler, AccessLevelHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Введите JWT токен в поле ниже. Пример: 'Bearer ваш_токен'",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddDbContext<AppDbConext>(options =>
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
