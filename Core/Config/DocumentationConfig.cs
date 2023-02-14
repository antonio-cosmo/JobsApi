using Microsoft.OpenApi.Models;

namespace JobsApi.Core.Config
{
  public static class DocumentationConfig
  {
    public static void RegisterSwagger(this IServiceCollection services)
    {
      services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo
      {
        Version = "v1",
        Title = "Jobs API",
        Description = "API de um portal de vagas",
        Contact = new OpenApiContact
        {
          Name = "Antônio Cosmo",
          Email = "antoniocosmosilvaneto@gmail.com",
          Url = new Uri("https://github.com/antonio-cosmo"),
        }
      }));
    }
  }
}