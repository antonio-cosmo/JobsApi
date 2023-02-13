using JobsApi.Api.Common.Assemblers;
using JobsApi.Api.Jobs.Assemblers;
using JobsApi.Api.Jobs.Dtos;

namespace JobsApi.Core.Config
{
  public static class AssemblersConfig
  {
    public static void RegisterAssemblers(this IServiceCollection services)
    {
      services.AddScoped<IAssembler<JobSummaryResponse>, JobSummaryAssembler>();
      services.AddScoped<IAssembler<JobDetailsResponse>, JobDetailsAssembler>();
      services.AddScoped<IPagedAssembler<JobSummaryResponse>, JobSummaryPagedAssembler>();
    }
  }
}