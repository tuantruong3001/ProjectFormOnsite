using App.Application.OptionsSetup;
using Microsoft.Extensions.Options;

namespace App.API.Middleware;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;

    public ApiKeyMiddleware(RequestDelegate next) => _next = next;
    public async Task Invoke(HttpContext context, IOptions<AuthOptions> authOptions)
    {
        if (!context.Request.Headers.TryGetValue("api-key", out var apiKey))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        if (apiKey.ToString() != authOptions.Value.ApiKey)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        await _next.Invoke(context);
    }
}