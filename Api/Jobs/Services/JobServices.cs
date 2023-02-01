using JobsApi.Core.AppExceptions;
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

    public Job Create(Job body)
    {
      return this._jobRepository.Create(body);
    }

    public ICollection<Job> FindAll()
    {
      return this._jobRepository.FindAll();
    }

    public Job FindById(int id)
    {
      var job = this._jobRepository.FindById(id);

      if (job is null) throw new ModelNotFound("Job with id not found");

      return job;
    }
  }
}