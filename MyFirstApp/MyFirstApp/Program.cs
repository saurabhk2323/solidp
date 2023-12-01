using MyFirstApp.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

// register middleware in services
builder.Services.AddTransient<MyCustomMiddleware>();

var app = builder.Build();


// it does not forward request to subsequent middleware
//app.Run(async (HttpContext context) =>
//{
//    await context.Response.WriteAsync("Hello ");
//});

// Middleware - 1
// so how to achieve chaining of middleware --> take help from "Use"
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    context.Response.Headers["content-type"] = "text/html";
    await context.Response.WriteAsync("<div>Middleware 1 starts </div>");
    await next(context); // passes context to next middleware
    await context.Response.WriteAsync("<div>Middleware 1 ends</div>");
});

// Middleware - 2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("<div>Middleware 2 starts</div>");
    await next(context);
    await context.Response.WriteAsync("<div>Middleware 2 ends</div>");
});

// Middleware - 3
// custom middleware
// this implementation can be simplified further using extension methods
//app.UseMiddleware<MyCustomMiddleware>();
app.UseMyCustomMiddleware();

// conventional middleware
app.UseHelloCustomMiddleware();

// Middleware - 4
// terminating middleware
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("<div>Terminating Middleware </div>");
});

app.Run();