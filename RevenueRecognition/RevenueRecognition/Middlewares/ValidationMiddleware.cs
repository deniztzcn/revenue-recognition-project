using System.Net;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RevenueRecognition.Middlewares;
//It works properly, tested 
public class ValidationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ValidationMiddleware> _logger;

    public ValidationMiddleware(RequestDelegate next,ILogger<ValidationMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);
        if (context.Response.StatusCode == 400 && context.Items["ModelState"] is ModelStateDictionary modelState)
        {
            _logger.LogError("Model validation error occured.");
            await HandleValidationAsync(context, modelState);
        }
        
    }

    private Task HandleValidationAsync(HttpContext context,ModelStateDictionary modelState)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Response.ContentType = "application/json";
        var errors = modelState
            .Where(e => e.Value.Errors.Count > 0)
            .ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
            );

        context.Response.ContentType = "application/json";
        var jsonResponse = System.Text.Json.JsonSerializer.Serialize(new { Errors = errors });

        return context.Response.WriteAsync(jsonResponse);
    }
}