using System.Reflection;
using Microsoft.Extensions.Primitives;

Console.WriteLine("***** Header Audit created by BinaryPatrick");
Console.WriteLine("***** https://github.com/binarypatrick/headeraudit");

var fileVersion = Assembly
    .GetExecutingAssembly()
    .GetCustomAttribute<AssemblyFileVersionAttribute>()?
    .Version;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options => options.AddServerHeader = false);

WebApplication app = builder.Build();
app.Use(async (HttpContext context, Func<Task> _) =>
{
    context.Response.Headers.TryAdd("X-Developed-By", "https://github.com/binarypatrick/headeraudit");
    context.Response.Headers.TryAdd("X-Version", fileVersion);
    Dictionary<string, StringValues> headers = context.Request.Headers.ToDictionary();
    await context.Response.WriteAsJsonAsync(new { RequestHeaders = headers });
});

app.Run();
