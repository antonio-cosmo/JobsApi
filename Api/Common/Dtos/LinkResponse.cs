namespace JobsApi.Api.Common.Dtos
{
  public class LinkResponse
  {


    public string? Href { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Rel { get; set; } = string.Empty;

    public LinkResponse(string? href, string type, string rel)
    {
      Href = href;
      Type = type;
      Rel = rel;
    }

  }
}