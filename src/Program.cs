using Microsoft.Extensions.Primitives;

WebApplication app = WebApplication.CreateBuilder(args).Build();

app.Use(async (HttpContext context, Func<Task> next) =>
{
    Dictionary<string, StringValues> headers = context.Request.Headers.ToDictionary();
    await context.Response.WriteAsJsonAsync(new { RequestHeaders = headers });
});

app.Run();
