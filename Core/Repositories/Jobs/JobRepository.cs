using JobsApi.Core.Database.Contexts;
using JobsApi.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsApi.Core.Repositories.Jobs
{
  public class JobRepository : IJobRepository
  {
    private readonly AppDbContext _context;

    public JobRepository(AppDbContext context)
    {
      _context = context;
    }

    public Job Create(Job data)
    {
      this._context.Jobs.Add(data);
      this._context.SaveChanges();

      return data;
    }

    public void DeleteById(int id)
    {
      var job = this._context.Jobs.Find(id);
      if (job is not null)
      {
        this._context.Jobs.Remove(job);
        this._context.SaveChanges();
      }
    }

    public bool ExistsById(int id)
    {
      return this._context.Jobs.Any(j => j.Id == id);
    }

    public ICollection<Job> FindAll()
    {
      return this._context.Jobs.AsNoTracking().ToList();
    }

    public PagedResult<Job> FindAll(PaginationOptions options)
    {
      var totalElements = _context.Jobs.Count();
      var items = _context.Jobs.Skip((options.PageNumber - 1) * options.PageSize)
                               .Take(options.PageSize)
                               .ToList();
      return new PagedResult<Job>(items, options.PageNumber, options.PageSize, totalElements);

    }

    public Job? FindById(int id)
    {
      return this._context.Jobs.AsNoTracking().FirstOrDefault(j => j.Id == id);
    }

    public Job Update(Job data)
    {
      this._context.Jobs.Update(data);
      this._context.SaveChanges();

      return data;
    }


  }
}