using JobsApi.Core.Database.Contexts;

namespace JobsApi.Core.Config;

public static class DatabaseConfig
{
  public static void RegisterDatabase(this IServiceCollection services)
  {
    services.AddDbContext<AppDbContext>();
  }
}