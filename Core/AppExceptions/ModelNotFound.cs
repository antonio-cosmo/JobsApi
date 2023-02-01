namespace JobsApi.Core.AppExceptions
{
  public class ModelNotFound : Exception
  {
    public ModelNotFound(string message = "Model not found") : base(message) { }
  }
}