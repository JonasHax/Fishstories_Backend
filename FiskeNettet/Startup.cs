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

            services.AddSingleton<IPeopleStoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<PeopleStoreDatabaseSettings>>().Value);

            // Services
            services.AddSingleton<IPeopleService, PeopleService>();

            // Repositories
            services.AddSingleton<IPeopleRepository, PeopleRepository>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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