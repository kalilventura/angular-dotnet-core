using CompanyAPI.DTO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CompanyAPI.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                _logger.LogInformation($@"Path: {httpContext.Request.Path}");
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var result = new Result();
                result.Messages.Add(ex.Message);
                var jsonResponse = JsonConvert.SerializeObject(result);

                httpContext.Response.Clear();
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                _logger.LogCritical(ex.Message);
                await httpContext.Response.WriteAsync(jsonResponse);
            }
        }
    }
    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder) => builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}