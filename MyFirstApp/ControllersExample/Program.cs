var builder = WebApplication.CreateBuilder(args);

// adds all controllers classes as services at once
builder.Services.AddControllers();

var app = builder.Build();


//app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    // detects all controllers from project and routing for each action items
//    endpoints.MapControllers();
//});

// instead of above two steps,
app.MapControllers();

app.Run();
