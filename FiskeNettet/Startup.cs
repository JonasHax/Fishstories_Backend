using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiskeNettet.Models;
using FiskeNettet.Repositories;
using FiskeNettet.Repositories.Interfaces;
using FiskeNettet.Services;
using FiskeNettet.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace FiskeNettet
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
            // Database Configurations
            services.Configure<PeopleStoreDatabaseSettings>(
                Configuration.GetSection(nameof(PeopleStoreDatabaseSettings)));

            services.AddScoped<IPeopleStoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<PeopleStoreDatabaseSettings>>().Value);

            // Services
            services.AddScoped<IPeopleService, PeopleService>();

            // Repositories
            services.AddScoped<IPeopleRepository, PeopleRepository>();

            services.AddControllers();

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "FiskeNettet",
                    Description = ""
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FiskeNettet");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}