var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// GetEndPoint -> displayName & requestDelegate
// when called before "useRouting" -> returns null
app.Use(async (context, next) =>
{
    Endpoint endpoint = context.GetEndpoint();
    await next(context);
});

// enable routings
// along with this, we must have to use map* as well
app.UseRouting();

// GetEndPoint -> displayName & requestDelegate
// when called before "useRouting" -> returns null
// Note: if none of the defined endpoints matched, GetEndpoint returns null only
app.Use(async (context, next) =>
{
    Endpoint endpoint = context.GetEndpoint(); // map1 HTTP: GET
    await next(context);
});

// creating endpoints
// first of all endpoints are matched here
// if anyone endpoint matched, it doesn't execute others
app.UseEndpoints(endpoints =>
{
    // add your endpoints here

    // Map works for all kind of requests
    endpoints.MapGet("map1", async (context) =>
    {
        await context.Response.WriteAsync("In Map 1");
    });

    endpoints.MapPost("map2", async (context) =>
    {
        await context.Response.WriteAsync("In Map 2");
    });

});

// default execution - if endpoints don't match from above defined ones
app.Run(async (context) =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();