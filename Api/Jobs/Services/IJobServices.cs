using JobsApi.Core.Models;

namespace JobsApi.Api.Jobs.Services
{
  public interface IJobServices
  {
    ICollection<Job> FindAll();
  }
}