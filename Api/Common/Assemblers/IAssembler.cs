using JobsApi.Api.Jobs.Dtos;

namespace JobsApi.Api.Common.Assemblers
{
  public interface IAssembler<T> where T : ResourceResponse
  {
    T ToResource(T resource, HttpContext context);
    ICollection<T> ToResourceColletion(ICollection<T> resources, HttpContext context)
    {
      return resources.Select(r => ToResource(r, context)).ToList();
    }
  }
}