namespace JobsApi.Api.Jobs.Dtos
{
  public class JobSummaryResponse : ResourceResponse
  {
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public ICollection<string> Requirements { get; set; } = new List<string>();

  }
}