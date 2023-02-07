using System.Text.Json;
using FluentValidation;
using JobsApi.Api.Common.Dtos;
using JobsApi.Core.AppExceptions;

namespace JobsApi.Core.Middlewares
{
  public class ExceptionHandlerMidleware
  {
    private readonly RequestDelegate _next;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    public ExceptionHandlerMidleware(RequestDelegate next)
    {
      _next = next;
      _jsonSerializerOptions = new JsonSerializerOptions
      {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      };
    }

    public async Task Invoke(HttpContext context)
    {
      try
      {
        await this._next(context);
      }
      catch (ModelNotFoundException e)
      {
        await handleModelNotFoundExceptionAsync(context, e);
      }
      catch (ValidationException e)
      {
        await handleValidationJobRequestExceptionAsync(context, e);
      }
    }

    private Task handleValidationJobRequestExceptionAsync(HttpContext context, ValidationException e)
    {
      var body = new ValidationErrorResponse
      {
        Status = 400,
        Error = "Bad request",
        Cause = e.GetType().Name,
        Message = "Validation error",
        Timestamp = DateTime.Now,
        Erros = e.Errors.GroupBy(v => v.PropertyName).ToDictionary(v => v.Key, v => v.Select(v => v.ErrorMessage).ToArray())
      };

      context.Response.StatusCode = body.Status;
      context.Response.ContentType = "application/json";

      return context.Response.WriteAsync(JsonSerializer.Serialize(body, this._jsonSerializerOptions));
    }

    private Task handleModelNotFoundExceptionAsync(HttpContext context, ModelNotFoundException e)
    {
      var body = new ErrorResponse
      {
        Status = 404,
        Error = "Not Found",
        Cause = e.GetType().Name,
        Message = e.Message,
        Timestamp = DateTime.Now
      };

      context.Response.StatusCode = body.Status;
      context.Response.ContentType = "application/json";

      return context.Response.WriteAsync(JsonSerializer.Serialize(body, this._jsonSerializerOptions));
    }
  }
}