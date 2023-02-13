using FluentValidation;
using JobsApi.Api.Jobs.Dtos;
using JobsApi.Api.Jobs.Mappers;
using JobsApi.Core.AppExceptions;
using JobsApi.Core.Repositories;
using JobsApi.Core.Repositories.Jobs;

namespace JobsApi.Api.Jobs.Services
{
  public class JobServices : IJobServices
  {
    private readonly IJobRepository _jobRepository;
    private readonly IJobMapper _jobMapper;
    private readonly IValidator<JobRequest> _jobRequestValidator;

    public JobServices(
      IJobRepository jobRepository,
      IJobMapper jobMapper,
      IValidator<JobRequest> jobRequestValidator)
    {
      _jobRepository = jobRepository;
      _jobMapper = jobMapper;
      _jobRequestValidator = jobRequestValidator;
    }

    public JobDetailsResponse Create(JobRequest jobRequest)
    {
      this._jobRequestValidator.ValidateAndThrow(jobRequest);
      var jobBody = this._jobMapper.ToModel(jobRequest);
      return this._jobMapper.ToDetailsResponse(
        this._jobRepository.Create(jobBody)
      );
    }



    public void DeleteById(int id)
    {
      if (!this._jobRepository.ExistsById(id)) throw new ModelNotFoundException($"Job with id {id} not found");
      this._jobRepository.DeleteById(id);
    }

    public ICollection<JobSummaryResponse> FindAll()
    {
      var jobModel = this._jobRepository.FindAll();
      return jobModel.Select(job => this._jobMapper.ToSummaryResponse(job)).ToList();
    }

    public PagedResponse<JobSummaryResponse> FindAll(int page, int size)
    {
      var paginationOptions = new PaginationOptions(page, size);
      var pageResult = _jobRepository.FindAll(paginationOptions);
      return _jobMapper.ToPagedSummaryResponse(pageResult);

    }

    public JobDetailsResponse FindById(int id)
    {
      var job = this._jobRepository.FindById(id);

      if (job is null) throw new ModelNotFoundException($"Job with id {id} not found");

      return this._jobMapper.ToDetailsResponse(job);
    }

    public JobDetailsResponse UpdateById(int id, JobRequest jobRequest)
    {
      this._jobRequestValidator.ValidateAndThrow(jobRequest);

      if (!this._jobRepository.ExistsById(id)) throw new ModelNotFoundException($"Job with id {id} not found");

      var job = this._jobMapper.ToModel(jobRequest);
      job.Id = id;

      var jobUpdate = this._jobRepository.Update(job);

      return this._jobMapper.ToDetailsResponse(jobUpdate);
    }
  }
}