
using Serilog;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
     
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Serverfeil. Prøv en annen gang.");
            await context.Response.WriteAsync("En feil oppstod på serveren. Prøv igjen senere "+ex.Message);
        }
    }


}

