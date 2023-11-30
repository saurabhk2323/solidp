using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Gets created automatically on receiving Http request
// context contains the information about request/response with other information
app.Run(async (HttpContext context) =>
{
    StreamReader reader = new StreamReader(context.Request.Body);
    string body = await reader.ReadToEndAsync();

    // read query string values sent in body
    // converts query strings into dictinary object
    // reason behind StringValues: Query strings might consist more than one same key with different values
    Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

    if(queryDict.ContainsKey("age"))
    {
        string age = queryDict["age"][0];
        await context.Response.WriteAsync(age);
    }

    await context.Response.WriteAsync(body);
});

app.Run();
