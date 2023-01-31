using JobsApi.Core.Database.EntityConfigs;
using JobsApi.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsApi.Core.Database.Contexts;

public class AppDbContext : DbContext
{
  public DbSet<Job> Jobs => Set<Job>();

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql(@"Host=localhost:5432;Username=jobsApi;Password=jobsApi;Database=db_jobsapi");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new JobEntityConfig());
  }
}