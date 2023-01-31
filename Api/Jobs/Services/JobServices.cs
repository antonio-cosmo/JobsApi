using JobsApi.Core.Models;
using JobsApi.Core.Repositories.Jobs;

namespace JobsApi.Api.Jobs.Services
{
  public class JobServices : IJobServices
  {
    private readonly IJobRepository _jobRepository;

    public JobServices(IJobRepository jobRepository)
    {
      _jobRepository = jobRepository;
    }

    public ICollection<Job> FindAll()
    {
      return this._jobRepository.FindAll();
    }
  }
}