using JobsApi.Api.Jobs.Services;

namespace JobsApi.Core.Config
{
  public static class ServicesConfig
  {
    public static void RegisterJobServices(this IServiceCollection services)
    {
      services.AddScoped<IJobServices, JobServices>();
    }
  }
}