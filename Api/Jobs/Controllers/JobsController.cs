using JobsApi.Api.Jobs.Services;
using JobsApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobsApi.Api.Jobs.Controllers
{
  [ApiController]
  [Route("/api/jobs")]
  public class JobsController : ControllerBase
  {
    private readonly IJobServices _jobServices;

    public JobsController(IJobServices jobServices)
    {
      _jobServices = jobServices;
    }

    [HttpGet]
    public IActionResult GetJobs()
    {
      var response = this._jobServices.FindAll();
      return Ok(response);
    }

    [HttpGet("{id}")]
    public IActionResult GetJobById([FromRoute] int id)
    {
      return Ok(this._jobServices.FindById(id));
    }

    [HttpPost]
    public IActionResult CreateJob([FromBody] Job body)
    {
      var job = this._jobServices.Create(body);

      return CreatedAtAction(nameof(GetJobById), new { Id = body.Id }, body);
    }
  }
}