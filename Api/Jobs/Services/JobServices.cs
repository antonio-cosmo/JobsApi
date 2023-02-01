using JobsApi.Api.Jobs.Dtos;
using JobsApi.Api.Jobs.Mappers;
using JobsApi.Core.AppExceptions;
using JobsApi.Core.Repositories.Jobs;

namespace JobsApi.Api.Jobs.Services
{
  public class JobServices : IJobServices
  {
    private readonly IJobRepository _jobRepository;
    private readonly IJobMapper _jobMapper;

    public JobServices(IJobRepository jobRepository, IJobMapper jobMapper)
    {
      _jobRepository = jobRepository;
      _jobMapper = jobMapper;

    }

    public JobDetailsResponse Create(JobRequest body)
    {
      var jobBody = this._jobMapper.ToModel(body);
      return this._jobMapper.ToDetailsResponse(
        this._jobRepository.Create(jobBody)
      );
    }



    public void DeleteById(int id)
    {
      if (!this._jobRepository.ExistsById(id)) throw new ModelNotFound($"Job with id {id} not found");
      this._jobRepository.DeleteById(id);
    }

    public ICollection<JobSummaryResponse> FindAll()
    {
      var jobModel = this._jobRepository.FindAll();
      return jobModel.Select(job => this._jobMapper.ToSummaryResponse(job)).ToList();
    }

    public JobDetailsResponse FindById(int id)
    {
      var job = this._jobRepository.FindById(id);

      if (job is null) throw new ModelNotFound($"Job with id {id} not found");

      return this._jobMapper.ToDetailsResponse(job);
    }

    public JobDetailsResponse UpdateById(int id, JobRequest jobRequest)
    {
      if (!this._jobRepository.ExistsById(id)) throw new ModelNotFound($"Job with id {id} not found");

      var job = this._jobMapper.ToModel(jobRequest);
      job.Id = id;

      var jobUpdate = this._jobRepository.Update(job);

      return this._jobMapper.ToDetailsResponse(jobUpdate);
    }
  }
}