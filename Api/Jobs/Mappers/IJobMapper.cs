using JobsApi.Api.Jobs.Dtos;
using JobsApi.Core.Models;

namespace JobsApi.Api.Jobs.Mappers
{
  public interface IJobMapper
  {
    JobDetailsResponse ToDetailsResponse(Job job);
    JobSummaryResponse ToSummaryResponse(Job job);
    Job ToModel(JobRequest job);
  }
}