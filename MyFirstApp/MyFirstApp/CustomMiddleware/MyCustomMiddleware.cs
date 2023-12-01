namespace MyFirstApp.CustomMiddleware
{
    // implement IMiddleware to use this class as Middleware
    // this needs to be registered as well in Program.cs | under services
    public class MyCustomMiddleware : IMiddleware
    {
        // same arguments as app.Use()
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("<div>My Custom Middleware - Starts</div>");
            await next(context);
            await context.Response.WriteAsync("<div>My Custom Middleware - Ends</div>");
        }
    }

    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app) => app.UseMiddleware<MyCustomMiddleware>();
    }
}
