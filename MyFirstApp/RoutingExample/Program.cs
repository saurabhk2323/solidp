var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// enable routings
app.UseRouting();

// Route Paramters - {employeeName}
// default paramters - {id=1}
// optional parameters - {id?}
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
    endpoints.Map("employee/profile/{employeeName=harshal}", async (context) =>
    {
        string? empName = Convert.ToString(context.Request.RouteValues["employeeName"]); // if employee name is not specified in url, default value is considered

        await context.Response.WriteAsync($"Employee Name: {empName}");
    });

    // default values
    // products/details/{id=1}
    endpoints.Map("products/details/{id=1}", async (context) =>
    {
        int id = Convert.ToInt32(context.Request.RouteValues["id"]);

        await context.Response.WriteAsync($"Product details - {id}");
    });

    // optional parameters
    endpoints.Map("customers/details/{cid?}", async (context) =>
    {
        int cid = Convert.ToInt32(context.Request.RouteValues["cid"]);

        await context.Response.WriteAsync($"Customer details - {cid}");
    });
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();