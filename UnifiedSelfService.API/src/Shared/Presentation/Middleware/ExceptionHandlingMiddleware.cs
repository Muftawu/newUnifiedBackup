using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context); // Pass request to next middleware/controller
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred."); // Log the error

            context.Response.ContentType = "application/json"; 
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; 

            var errorResponse = new
            {
                Message = "An internal server error occurred. Please try again later."
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse)); // Send generic error
        }
    }
}
