var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

// Gets created automatically on receiving Http request
// context contains the information about request/response with other information
app.Run(async (HttpContext context) =>
{
    // add response headers
    // context.Response.Headers: it's a dictionary
    context.Response.Headers["myKey"] = "myValue";

    // hiding server info
    context.Response.Headers["server"] = "my server";

    // content-type: use to specify the type of response being sent

    // content-type: text/html; 
    context.Response.Headers["content-type"] = "text/html";

    // cache-control: max-age=60(seconds) - if same url is hit again, it reads the values from browser cache

    // access-control-allow-origin

    // location: to redirect

    // assign status codes
    context.Response.StatusCode = 400;

    // use to write anything in body
    await context.Response.WriteAsync("<h1>Hello</h1>");

    // if you intend to pass html values, you need to specify headers first


    await context.Response.WriteAsync("<h2>World</h2>");
});

app.Run();
