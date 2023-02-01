using JobsApi.Api.Jobs.Mappers;

namespace JobsApi.Core.Config
{
  public static class MapperConfig
  {
    public static void RegisterJobMapper(this IServiceCollection services)
    {
      services.AddScoped<IJobMapper, JobMapper>();
    }
  }
}