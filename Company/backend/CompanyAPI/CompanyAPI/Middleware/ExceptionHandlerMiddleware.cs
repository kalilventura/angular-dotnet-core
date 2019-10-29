// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
namespace CompanyAPI.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next) { _next = next; }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static class ExceptionHandlerMiddlewareExtensions
        {
            public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder) => builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}