using JobsApi.Core.Models;

namespace JobsApi.Core.Repositories.Jobs
{
  public interface IJobRepository : IRepositoryBase<Job, int>, IPagedRepository<Job>
  { }
}