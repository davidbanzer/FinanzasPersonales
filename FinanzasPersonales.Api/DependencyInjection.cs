
using FinanzasPersonales.Api.Common.Mapping;
using FinanzasPersonales.Api.Filters;

namespace FinanzasPersonales.Api;

public static class DependencyInjection
{
  public static IServiceCollection AddPresentation(this IServiceCollection services)
  {
    services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    services.AddMappings();
    return services;

  }
}