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

    public void DeleteById(int id)
    {
      if (!this._jobRepository.ExistsById(id)) throw new ModelNotFound($"Job with id {id} not found");
      this._jobRepository.DeleteById(id);
    }

    public ICollection<Job> FindAll()
    {
      return this._jobRepository.FindAll();
    }

    public Job FindById(int id)
    {
      var job = this._jobRepository.FindById(id);

      if (job is null) throw new ModelNotFound($"Job with id {id} not found");

      return job;
    }

    public Job UpdateById(int id, Job body)
    {
      if (!this._jobRepository.ExistsById(id)) throw new ModelNotFound($"Job with id {id} not found");

      body.Id = id;

      return this._jobRepository.Update(body);
    }
  }
}