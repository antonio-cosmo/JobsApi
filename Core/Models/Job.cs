namespace JobsApi.Core.Models
{
public class Job
{
  public int Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public double Salary { get; set; }
  public string Requirements { get; set; } = string.Empty;
}
}