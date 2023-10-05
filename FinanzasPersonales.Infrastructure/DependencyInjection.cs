

using FinanzasPersonales.Application.Common.Interface.Authentication;
using FinanzasPersonales.Application.Common.Interfaces.Persistance;
using FinanzasPersonales.Application.Common.Interfaces.Services;
using FinanzasPersonales.Infrastructure.Authentication;
using FinanzasPersonales.Infrastructure.Persistance;
using FinanzasPersonales.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace FinanzasPersonales.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastucture(
    this IServiceCollection services,
    ConfigurationManager configuration)
  {
    services.AddAuth(configuration)
            .AddPersistance();
    services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
    
    return services;
  }
  public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
  {
    var jwtSettings = new JwtSettings();
    configuration.Bind(JwtSettings.SectionName, jwtSettings);

    services.AddSingleton(Options.Create(jwtSettings));
    services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
      {
        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidIssuer = jwtSettings.Issuer,
          ValidateAudience = true,
          ValidAudience = jwtSettings.Audience,
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
          ValidateLifetime = true,
          ClockSkew = TimeSpan.Zero
        };
      });
      
    return services;
  }

  public static IServiceCollection AddPersistance(this IServiceCollection services)
  {
    services.AddDbContext<FinanzasPersonalesDbContext>(options =>
        options.UseMySql("Server=localhost;Database=finanzas_personales;User Id=root;Password=root;", new MySqlServerVersion(new Version(8, 0, 30))));
    services.AddScoped<IAccountRepository, AccountRepository>();
    services.AddScoped<IUserRepository, UserRepository>();

    return services;
  }
}