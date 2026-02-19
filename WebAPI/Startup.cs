using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Middleware;
using WebAPI.Model.Services;
using WebAPI.Model.Services.Implementation;
using WebAPI.Model.Services.Interface;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers()
                 .AddJsonOptions(options =>
                 {
                     options.JsonSerializerOptions.PropertyNamingPolicy = null;
                 }); 

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });


            services.AddDbContext<IdealERPContext>(options => options.UseSqlServer(Configuration.GetConnectionString("IdealERPConnection")));
            services.AddScoped<IUser, Usersvr>();
            services.AddScoped<IOrganisationsvr, Organisationsvr>();
            services.AddScoped<ICompany, Companysvr>();
            services.AddScoped<ValidationErrors>();
            services.AddScoped<APIError>();
            
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IMasterData, MasterData>();

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));

            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            // app.UseMiddleware<ApplicationAccessMiddleware>();

            app.UseMiddleware<ExceptionMiddleware>();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
