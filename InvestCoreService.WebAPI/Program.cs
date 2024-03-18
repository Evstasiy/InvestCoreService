using InvestCoreService.API.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using InvestCoreService.Application.Interfaces.Services;
using InvestCoreService.Persistence.Postgres;
using Microsoft.EntityFrameworkCore;
using InvestCoreService.Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ISecurityExchangeService, SecurityExchangeService>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();
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
