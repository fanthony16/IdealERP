using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Middleware
{
    public class ApplicationAccessMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IDictionary<string, string> _allowedApps;
        public ApplicationAccessMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            this.next = next;
            _allowedApps = configuration.GetSection("AllowedApplications").Get<Dictionary<string, string>>()
                ?? new Dictionary<string, string>();

        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("X-App-Id", out var appId) ||
                !context.Request.Headers.TryGetValue("X-App-Secret", out var appSecret))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Missing application credentials.");
                return;
            }

            if (!_allowedApps.TryGetValue(appId!, out var expectedSecret) || expectedSecret != appSecret)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Application is not authorized.");
                return;
            }

            // Store application identity for later use
            context.Items["ApplicationId"] = appId.ToString();
            await next(context);

        }
    }
}
