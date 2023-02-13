using JobsApi.Api.Jobs.Dtos;

namespace JobsApi.Api.Common.Assemblers
{
  public interface IPagedAssembler<R> where R : ResourceResponse
  {
    PagedResponse<R> ToPagedResource(PagedResponse<R> pagedResource, HttpContext context);
  }
}