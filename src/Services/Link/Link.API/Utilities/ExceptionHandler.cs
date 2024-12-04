using Link.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;



namespace Link.API.Utilities;

public sealed class ExceptionHandler : IMiddleware
{
    private readonly ILogger<ExceptionHandler> _logger;

    public ExceptionHandler(ILogger<ExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            ProblemDetails problemDeatils = new()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Title = "Server error",
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                Detail = ex.Message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(
                new Result(
                    isSuccess: false,
                    error: new Error(
                        HttpStatusCode.InternalServerError.ToString(),
                        JsonSerializer.Serialize(problemDeatils))));
        }
    }
}
