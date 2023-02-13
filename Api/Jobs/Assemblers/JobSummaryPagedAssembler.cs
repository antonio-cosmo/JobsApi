using JobsApi.Api.Common.Assemblers;
using JobsApi.Api.Common.Dtos;
using JobsApi.Api.Jobs.Dtos;

namespace JobsApi.Api.Jobs.Assemblers
{
  public class JobSummaryPagedAssembler : IPagedAssembler<JobSummaryResponse>
  {

    private readonly LinkGenerator _linkGenerator;
    private readonly IAssembler<JobSummaryResponse> _jobSummaryResponseAssembler;

    public JobSummaryPagedAssembler(LinkGenerator linkGenerator, IAssembler<JobSummaryResponse> jobSummaryResponseAssembler)
    {
      _linkGenerator = linkGenerator;
      _jobSummaryResponseAssembler = jobSummaryResponseAssembler;
    }

    public PagedResponse<JobSummaryResponse> ToPagedResource(PagedResponse<JobSummaryResponse> pagedResource, HttpContext context)
    {
      pagedResource.Items = _jobSummaryResponseAssembler.ToResourceColletion(pagedResource.Items, context);

      var firstPageLink = new LinkResponse(
        _linkGenerator.GetUriByName(context, "FindAllJobs", new { page = pagedResource.FirstPage, size = pagedResource.PageSize }),
        "GET",
        "firstPage"
      );

      var lastPageLink = new LinkResponse(
        _linkGenerator.GetUriByName(context, "FindAllJobs", new { page = pagedResource.LastPage, size = pagedResource.PageSize }),
        "GET",
        "lastPage"
      );

      var nextPageLink = new LinkResponse(
        _linkGenerator.GetUriByName(context, "FindAllJobs", new { page = pagedResource.PageNumber + 1, size = pagedResource.PageSize }),
        "GET",
        "nextPage"
      );

      var previousPageLink = new LinkResponse(
       _linkGenerator.GetUriByName(context, "FindAllJobs", new { page = pagedResource.PageNumber - 1, size = pagedResource.PageSize }),
       "GET",
       "previousPage"
     );

      pagedResource.AddLinks(firstPageLink, lastPageLink);

      pagedResource.AddLinkIf(pagedResource.HasNextPage, nextPageLink);
      pagedResource.AddLinkIf(pagedResource.HasPreviousPage, previousPageLink);
      return pagedResource;
    }
  }
}