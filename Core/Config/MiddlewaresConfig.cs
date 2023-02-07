using JobsApi.Core.Middlewares;

namespace JobsApi.Core.Config
{
  public static class MiddlewaresConfig
  {
    public static void RegisterMiddlewares(this WebApplication app)
    {
      app.UseMiddleware<ExceptionHandlerMidleware>();
    }
  }
}