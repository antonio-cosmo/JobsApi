using JobsApi.Api.Common.Assemblers;
using JobsApi.Api.Common.Dtos;
using JobsApi.Api.Jobs.Dtos;

namespace JobsApi.Api.Jobs.Assemblers
{
  public class JobSummaryAssembler : IAssembler<JobSummaryResponse>
  {
    private readonly LinkGenerator _linkGenerator;

    public JobSummaryAssembler(LinkGenerator linkGenerator)
    {
      _linkGenerator = linkGenerator;
    }

    public JobSummaryResponse ToResource(JobSummaryResponse resource, HttpContext context)
    {
      var selfLink = new LinkResponse(
          this._linkGenerator.GetUriByName(context, "FindJobById", new { Id = resource.Id }),
          "GET",
          "self"
        );
      var updateLink = new LinkResponse(

      this._linkGenerator.GetUriByName(context, "UpdateJobById", new { Id = resource.Id }), "PUT",
        "update"
      );
      var deleteLink = new LinkResponse(
          this._linkGenerator.GetUriByName(context, "DeleteJobById", new { Id = resource.Id }),
         "DELETE",
         "delete"
      );

      resource.AddLinks(selfLink, updateLink, deleteLink);

      return resource;
    }
  }
}