var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// enable routings
app.UseRouting();

// Route Paramters - {employeeName}
// default paramters - {id=1}
// optional parameters - {id?}
// constraints - put some restriction over parameters \ check endpoint only if constraint is matched \
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

    // constraint over paramters
    // {id:int}, {active:bool}, {date:datetime} matches with 2030-01-01%2011:59%20pm
    // decimal
    // long
    // guid - a hexadecimal number that is universally unique
    // minlenght(value)
    //maxlength(value)
    //length(min,max)
    endpoints.Map("blogs/authors/{id:int?}", async (context) =>
    {
        int id = Convert.ToInt32(context.Request.RouteValues["id"]);

        await context.Response.WriteAsync($"blogs author id - {id}");
    });

    endpoints.Map("daily-digest-report/{reportDate:datetime}", async (context) =>
    {
        DateTime? datetime = Convert.ToDateTime(context.Request.RouteValues["reportDate"]);

        await context.Response.WriteAsync($"daily-digest-report time: {datetime}");
    });

    // cities/guid --? not cities/city/guid
    endpoints.Map("cities/{cityid:guid}", async context =>
    {
        string? guid = Convert.ToString(context.Request.RouteValues["cityid"]);

        await context.Response.WriteAsync($"cityid - {guid}");
    });

    // minlenght(value)
    // maxlength(value)
    // length(min,max)
    // length(value)
    // min(value) - matches with an integer value
    // max(value)
    // range(min, max)
    // alpha - only alphabets
    // regex(expression)
    // endpoints.Map("users/{username:minlength(5)=harshal}", async context =>
    // endpoints.Map("users/{username:maxlength(5)=harshal}", async context =>
    endpoints.Map("users/{username:length(5,10)=harshal}", async context =>
    {
        string? username = Convert.ToString(context.Request.RouteValues["username"]);

        await context.Response.WriteAsync($"username: {username}");
    });

    // regex
    endpoints.Map("sales-report/{year:int:min(1900)}/{month:regex(^(apr|jul|oct|jan)$)}", async context =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);

        await context.Response.WriteAsync($"sales report - {year}/{month}");

    });
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();