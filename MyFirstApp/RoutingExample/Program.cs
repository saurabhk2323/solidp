var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// enable routings
app.UseRouting();

// Route Paramters
app.UseEndpoints(endpoints =>
{
    // define route paramters as shown below --> filename and extension can be anything
    endpoints.Map("files/{filename}.{extension}", async (context) =>
    {
        // extract route params values - RouteValues: Dictionary
        string? fileName = Convert.ToString(context.Request.RouteValues["filename"]); // by default returns value as object type
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

        await context.Response.WriteAsync($"In files - {fileName}.{extension}");
    });

    // we can define any number of endpoints - route params
    endpoints.Map("employee/profile/{employeeName}", async (context) =>
    {
        string? empName = Convert.ToString(context.Request.RouteValues["employeeName"]);

        await context.Response.WriteAsync($"Employee Name: {empName}");
    });
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();