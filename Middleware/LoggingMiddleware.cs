using System.ComponentModel.DataAnnotations;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    
    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine($"[{DateTime.Now}] Request: {context.Request.Method} {context.Request.Path}");
        await _next(context);

        if(context.Response.StatusCode < 200 || context.Response.StatusCode > 299) //fjern dette om suksess skal vises i console inkludert "{}" fra linjene under.
        {
        Console.WriteLine($"[{DateTime.Now}] Response: {context.Response.StatusCode}");
        }
    }

}

