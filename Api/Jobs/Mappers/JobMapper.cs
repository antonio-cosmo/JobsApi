using JobsApi.Api.Jobs.Dtos;
using JobsApi.Core.Models;
using JobsApi.Core.Repositories;

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

    public PagedResponse<JobSummaryResponse> ToPagedSummaryResponse(PagedResult<Job> pageResult)
    {
      return new PagedResponse<JobSummaryResponse>
      {
        Items = pageResult.Items.Select(j => ToSummaryResponse(j)).ToList(),
        PageNumber = pageResult.PageNumber,
        PageSize = pageResult.PageSize,
        FirstPage = pageResult.FirstPage,
        LastPage = pageResult.LastPage,
        TotalPages = pageResult.TotalPages,
        TotalElements = pageResult.TotalElements,
        HasNextPage = pageResult.HasNextPage,
        HasPreviousPage = pageResult.HasPreviousPage
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