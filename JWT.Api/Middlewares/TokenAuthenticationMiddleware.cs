using JWT.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Net.Http.Headers;
using System.Net;

namespace JWT.Api.Middlewares
{
    public class TokenAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenAuthenticationMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,IAuthService authService)
        {
            var endpoint = context.GetEndpoint();
            if (endpoint == null)
            {
                await _next(context);
            }
            else
            {
                if (endpoint?.Metadata.GetMetadata<AllowAnonymousAttribute>() != null)
                {
                    await _next(context);
                    return;
                }

                if (!context.Request.Headers.TryGetValue(HeaderNames.Authorization, out var authHeader))
                {
                    await Unauthorized(context);
                    return;
                }

                var headerValue = authHeader.ToString();

                if (!headerValue.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    await Unauthorized(context);
                    return;
                }

                var token = headerValue.Substring("Bearer ".Length).Trim();

                if (string.IsNullOrWhiteSpace(token))
                {
                    await Unauthorized(context);
                    return;
                }

                var principal = await authService.ValidateUserWithToken(token);

                if (!principal)
                {
                    await Unauthorized(context);
                    return;
                }


                await _next(context);
            }
        }

        private static async Task Unauthorized(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Response.Headers["WWW-Authenticate"] = "Bearer";
            await context.Response.WriteAsync("Unauthorized");
        }
    }
}
