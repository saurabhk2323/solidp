var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Gets created automatically on receiving Http request
// context contains the information about request/response with other information
app.Run(async (HttpContext context) =>
{
    context.Response.Headers["Content-Type"] = "text/html";

    // reads path of the url
    // we can build our logic based on path
    string path = context.Request.Path;

    // reads mathod of the request
    string method = context.Request.Method;

    // ? separates path and query string || & separates two query strings
    // /dashboard?id=1&name=rahul : path = /dashboard, query string: id=1 || name = rahul

    if(method == "GET")
    {
        // context.Request.Query: A dictionary containing key value pair of query string & their values
        if(context.Request.Query.ContainsKey("id"))
        {
            string id = context.Request.Query["id"];
            await context.Response.WriteAsync($"<h1>{id}</h1>");
        }
    }

    // Accept: represents MIME type of response content to be accepted by the client | it generally tells server, i can take response in this type only
    // Accept-Language: language of response content
    // Host: server domain name
    // User-Agent: the type of browser from which request is coming to server
    // Cookie: contains cookie to send browser

    if(context.Request.Headers.ContainsKey("User-Agent"))
    {
        string userAgent = context.Request.Headers["User-Agent"];
        await context.Response.WriteAsync($"<h2>{userAgent}</h2>");
    }

    await context.Response.WriteAsync($"<p>{path}</p>");
    await context.Response.WriteAsync($"<p>{method}</p>");
});

app.Run();
