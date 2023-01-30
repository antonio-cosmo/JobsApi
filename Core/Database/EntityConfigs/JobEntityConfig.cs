using JobsApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobsApi.Core.Database.EntityConfigs;
public class JobEntityConfig : IEntityTypeConfiguration<Job>
{
  public void Configure(EntityTypeBuilder<Job> builder)
  {
    builder.ToTable("jobs");
    builder.HasKey(j => j.Id);
    builder.Property(j => j.Id).HasColumnName("id");

    builder.Property(j => j.Title)
            .HasColumnName("title")
            .HasColumnType("varchar(255)")
            .IsRequired();

    builder.Property(j => j.Salary)
        .HasColumnName("salary")
        .HasColumnType("numeric(6,2)")
        .IsRequired();

    builder.Property(j => j.Requirements)
          .HasColumnName("requirements")
          .HasColumnType("varchar(500)")
          .IsRequired();
  }
}