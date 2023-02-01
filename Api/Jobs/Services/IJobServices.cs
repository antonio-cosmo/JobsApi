using JobsApi.Core.Models;

namespace JobsApi.Api.Jobs.Services
{
  public interface IJobServices
  {
    ICollection<Job> FindAll();
    Job FindById(int id);
    Job Create(Job body);
    Job UpdateById(int id, Job body);
    void DeleteById(int id);
  }
}