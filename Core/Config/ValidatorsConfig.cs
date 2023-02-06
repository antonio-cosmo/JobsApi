using FluentValidation;
using JobsApi.Api.Jobs.Dtos;
using JobsApi.Api.Jobs.Validators;

namespace JobsApi.Core.Config
{
  public static class ValidatorsConfig
  {
    public static void RegisterJobRequestValidator(this IServiceCollection services)
    {
      services.AddScoped<IValidator<JobRequest>, JobRequestValidator>();
    }
  }
}