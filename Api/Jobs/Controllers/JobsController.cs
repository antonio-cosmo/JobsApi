using JobsApi.Api.Jobs.Services;
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
  }
}