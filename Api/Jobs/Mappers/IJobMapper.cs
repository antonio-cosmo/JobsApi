using JobsApi.Api.Jobs.Dtos;
using JobsApi.Core.Models;
using JobsApi.Core.Repositories;

namespace JobsApi.Api.Jobs.Mappers
{
  public interface IJobMapper
  {
    JobDetailsResponse ToDetailsResponse(Job job);
    JobSummaryResponse ToSummaryResponse(Job job);
    PagedResponse<JobSummaryResponse> ToPagedSummaryResponse(PagedResult<Job> pageResult);
    Job ToModel(JobRequest job);
  }
}