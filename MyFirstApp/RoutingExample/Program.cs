var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// enable routings
// along with this, we must have to use map* as well
app.UseRouting();

// creating endpoints
// first of all endpoints are matched here
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