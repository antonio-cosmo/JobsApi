namespace JobsApi.Api.Common.Dtos
{
  public class ValidationErrorResponse : ErrorResponse
  {
    public IDictionary<string, string[]>? Erros { get; set; }
  }
}