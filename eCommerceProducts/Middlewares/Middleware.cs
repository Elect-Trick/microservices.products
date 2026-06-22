using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace eCommerceProducts.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlingMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleWare> _logger;

        public ExceptionHandlingMiddleWare(RequestDelegate next, ILogger<ExceptionHandlingMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {

                await _next(httpContext);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);

                if (ex.InnerException is not null)
                {
                    _logger.LogError(ex.InnerException.Message);

                }

                //Internal server error
                httpContext.Response.StatusCode = 500;

                await httpContext.Response.WriteAsJsonAsync(new
                {
                    Message = ex.InnerException.Message
                });
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleWare>();
        }
    }
}
