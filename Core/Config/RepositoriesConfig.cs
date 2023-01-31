using JobsApi.Core.Repositories.Jobs;

namespace JobsApi.Core.Config
{
  public static class RepositoriesConfig
  {
    public static void RegisterJobRepository(this IServiceCollection services)
    {
      services.AddScoped<IJobRepository, JobRepository>();
    }
  }
}