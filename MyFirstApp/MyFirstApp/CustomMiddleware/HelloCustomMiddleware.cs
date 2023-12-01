using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyFirstApp.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HelloCustomMiddleware
    {
        private readonly RequestDelegate _next;

        // automatically passes subsequent middleware into this
        public HelloCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // gets HttpContext object automatically
        public async Task Invoke(HttpContext httpContext)
        {
            // before logic
            await httpContext.Response.WriteAsync("<div>Conventional middleware starts</div>");

            // pass the context to next middleware
            await _next(httpContext);

            // after logic
            await httpContext.Response.WriteAsync("<div>Conventional middleware ends</div>");

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HelloCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseHelloCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HelloCustomMiddleware>();
        }
    }
}
