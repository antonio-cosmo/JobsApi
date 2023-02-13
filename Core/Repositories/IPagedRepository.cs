namespace JobsApi.Core.Repositories
{
  public interface IPagedRepository<Model>
  {
    PagedResult<Model> FindAll(PaginationOptions options);
  }
}