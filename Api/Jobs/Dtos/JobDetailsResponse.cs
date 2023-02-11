namespace JobsApi.Api.Jobs.Dtos
{
  public class JobDetailsResponse : ResourceResponse
  {
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public double Salary { get; set; }
    public ICollection<string> Requirements { get; set; } = new List<string>();
  }
}