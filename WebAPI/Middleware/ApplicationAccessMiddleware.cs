using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Model.Services;

namespace WebAPI.Middleware
{
    public class ApplicationAccessMiddleware
    {
        private readonly RequestDelegate next;
        private IdealERPContext dbcontext;
        private IPasswordHasher hasher;
        private IDictionary<string, string> _allowedApps;
        public ApplicationAccessMiddleware(RequestDelegate next)
        {

            this.next = next;

        }

        private Dictionary<string,string> GetAllowedApplications(List<TblApplicationRegistration> dballowedapps)
        {
            Dictionary<string, string> allowedappsdic = new();

            //var dballowedapps = dbcontext.TblApplicationRegistrations.Where(x => x.IsActive== true).ToList();

            if (dballowedapps!=null)
            {
                foreach (var apps in dballowedapps)
                {
                    allowedappsdic.Add(apps.ApplicationId.ToString(), apps.SecretHash);
                }
                return allowedappsdic;
            }
            return new Dictionary<string, string>();
        }

        public async Task InvokeAsync(HttpContext context, IdealERPContext _dbContext, IPasswordHasher hasher)
        {


            var dballowedapps = _dbContext.TblApplicationRegistrations.Where(x => x.IsActive == true).ToList();

            _allowedApps = GetAllowedApplications(dballowedapps) ?? new Dictionary<string, string>();

            if (!context.Request.Headers.TryGetValue("X-App-Id", out var appId) ||
                !context.Request.Headers.TryGetValue("X-App-Secret", out var appSecret))
            {

                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Missing application credentials.");
                return;

            }


            if (!_allowedApps.TryGetValue(appId!.ToString().ToLower(), out var expectedSecret) || expectedSecret != hasher.HashPassword(appSecret))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;

                //await context.Response.WriteAsync($"Application is not authorized. Paased ID: {appId} Expected HSecret: {expectedSecret} Found Records: {_allowedApps.Count()} Passed Secret : {appSecret} Hashed Passed Secret : {hasher.HashPassword(appSecret)}");

                await context.Response.WriteAsync($"Invalid Application ID or Secret");

                return;


            }

            // Store application identity for later use
            context.Items["ApplicationId"] = appId.ToString();
            await next(context);

        }
    }
}
