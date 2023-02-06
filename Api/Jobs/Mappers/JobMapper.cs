using JobsApi.Api.Jobs.Dtos;
using JobsApi.Core.Models;

namespace JobsApi.Api.Jobs.Mappers
{
  public class JobMapper : IJobMapper
  {
    public JobDetailsResponse ToDetailsResponse(Job job)
    {
      return new JobDetailsResponse
      {
        Id = job.Id,
        Title = job.Title,
        Salary = job.Salary,
        Requirements = job.Requirements.Split(';')
      };
    }

    public Job ToModel(JobRequest job)
    {
      return new Job
      {
        Title = job.Title,
        Salary = job.Salary,
        Requirements = String.Join(';', job.Requirements)
      };
    }

    public JobSummaryResponse ToSummaryResponse(Job job)
    {
      return new JobSummaryResponse
      {
        Id = job.Id,
        Title = job.Title,
        Requirements = job.Requirements.Split(';')
      };
    }
  }
}