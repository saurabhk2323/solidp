var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// enable routings
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    // url template with more segments:  a/b/c/d > a/b/c

    // literal text has more precedence than a parameter segment: a/b > a/{parameter}

    // with constraint more precedence than w/o constraint:  a/{b}:int > a/{b}

    // catch all params:  a/{b} > a/**
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();