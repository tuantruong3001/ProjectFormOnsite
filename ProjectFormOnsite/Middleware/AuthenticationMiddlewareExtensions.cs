using Microsoft.AspNetCore.Authentication;

namespace App.API.Middleware;

public static class AuthenticationMiddlewareExtensions
{
    public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder appBuilder) => appBuilder.UseMiddleware<ApiKeyMiddleware>();
}