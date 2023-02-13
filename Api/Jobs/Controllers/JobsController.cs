using JobsApi.Api.Common.Assemblers;
using JobsApi.Api.Jobs.Dtos;
using JobsApi.Api.Jobs.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobsApi.Api.Jobs.Controllers
{
  [ApiController]
  [Route("/api/jobs")]
  public class JobsController : ControllerBase
  {
    private readonly IJobServices _jobServices;
    private readonly IPagedAssembler<JobSummaryResponse> _jobSummaryPagedAssembler;
    private readonly IAssembler<JobDetailsResponse> _jobDetailsAssembler;
    public JobsController(
      IJobServices jobServices,
      IPagedAssembler<JobSummaryResponse> jobSummaryPagedAssembler,
      IAssembler<JobDetailsResponse> jobDetailsAssembler)
    {
      _jobServices = jobServices;
      _jobSummaryPagedAssembler = jobSummaryPagedAssembler;
      _jobDetailsAssembler = jobDetailsAssembler;

    }

    [HttpGet(Name = "FindAllJobs")]
    public IActionResult GetJobs([FromQuery] int page, [FromQuery] int size)
    {
      var body = this._jobServices.FindAll(page, size);

      return Ok(_jobSummaryPagedAssembler.ToPagedResource(body, HttpContext));
    }

    [HttpGet("{id}", Name = "FindJobById")]
    public IActionResult GetJobById([FromRoute] int id)
    {
      var body = this._jobServices.FindById(id);
      return Ok(_jobDetailsAssembler.ToResource(body, HttpContext));
    }

    [HttpPost(Name = "CreateJob")]
    public IActionResult CreateJob([FromBody] JobRequest body)
    {
      var job = this._jobServices.Create(body);

      return CreatedAtAction(
        nameof(GetJobById),
        new { Id = job.Id },
        _jobDetailsAssembler.ToResource(job, HttpContext)
      );
    }

    [HttpPut("{id}", Name = "UpdateJobById")]
    public IActionResult UpdateJob([FromRoute] int id, [FromBody] JobRequest body)
    {

      var job = this._jobServices.UpdateById(id, body);

      return Ok(_jobDetailsAssembler.ToResource(job, HttpContext));
    }

    [HttpDelete("{id}", Name = "DeleteJobById")]
    public IActionResult DeleteJob([FromRoute] int id)
    {
      this._jobServices.DeleteById(id);

      return NoContent();
    }
  }
}