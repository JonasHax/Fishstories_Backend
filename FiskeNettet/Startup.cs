using FiskeNettet.Entities.DatabaseSettings;
using FiskeNettet.Models;
using FiskeNettet.Repositories;
using FiskeNettet.Repositories.Interfaces;
using FiskeNettet.Services;
using FiskeNettet.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
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
            // Generic pattern
            services.Configure<MongoDbSettings>(Configuration.GetSection("MongoDbSettings"));

            services.AddScoped<IMongoDbSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            // Cors
            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(
            //        builder =>
            //        {
            //            builder.WithOrigins("http://localhost:3000", "http://localhost:5001", "http://127.0.0.1:8887", "http://192.168.87.128:8887", "http://localhost:8887")
            //                .WithHeaders(HeaderNames.AccessControlAllowHeaders, "*");
            //        });
            //});
            services.AddCors();

            // Services
            services.AddScoped<IFishingSpotService, FishingSpotService>();
            services.AddScoped<ICatchReportService, CatchReportService>();

            // Repositories
            //services.AddScoped<IFishingSpotRepository, FishingSpotRepository>();
            //services.AddScoped<ICatchReportRepository, CatchReportRepository>();

            // Generic Repository
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

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

            //app.UseCors();
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

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