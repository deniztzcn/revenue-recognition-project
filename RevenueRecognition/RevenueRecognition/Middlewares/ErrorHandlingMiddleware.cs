using Microsoft.AspNetCore.Mvc;
using RevenueRecognition.Exceptions;

namespace RevenueRecognition.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            _logger.LogError(ex, ex.Message);

            var problemDetails = new ProblemDetails()
            {
                Status = StatusCodes.Status404NotFound,
                Title = ex.Message
            };

            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (NotFoundException ex)
        {
            _logger.LogError(ex, ex.Message);

            var problemDetails = new ProblemDetails()
            {
                Status = StatusCodes.Status404NotFound,
                Title = ex.Message
            };

            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}