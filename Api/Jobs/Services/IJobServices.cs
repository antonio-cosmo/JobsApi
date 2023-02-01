using JobsApi.Api.Jobs.Dtos;

namespace JobsApi.Api.Jobs.Services
{
  public interface IJobServices
  {
    ICollection<JobSummaryResponse> FindAll();
    JobDetailsResponse FindById(int id);
    JobDetailsResponse Create(JobRequest jobRequest);
    JobDetailsResponse UpdateById(int id, JobRequest jobRequest);
    void DeleteById(int id);
  }
}