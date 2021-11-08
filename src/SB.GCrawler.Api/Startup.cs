using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SB.GCrawler.Api.Logics;
using SB.GCrawler.Api.Services.Database;
using SB.GCrawler.Api.Services.SiteCrawlers;
using SB.GCrawler.Services.RobotsTexts;

namespace SB.GCrawler.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddJwt();
            services.AddHttpContextAccessor();
            services.AddScoped<IRobotsTextsService, RobotsTextsService>();
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SB.GCrawler.Api", Version = "v1" });
            });

            services.UseAutoDI();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SB.GCrawler.Api"));

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            MigrateDatabase(app);
            StartSitesCrawl(app);
        }

        /// <summary>
        /// 
        /// /// </summary>
        /// <param name="app"></param>
        private void MigrateDatabase(IApplicationBuilder app)
        {
            var scopeFactory = app.ApplicationServices.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();

            var databaseService = scope.ServiceProvider.GetService<IDatabaseService>();
            databaseService.MigrateDatabase();
        }

        /// <summary>
        /// 
        /// /// </summary>
        /// <param name="app"></param>
        private void StartSitesCrawl(IApplicationBuilder app)
        {
            var scopeFactory = app.ApplicationServices.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();

            var databaseService = scope.ServiceProvider.GetService<ISiteCrawlerService>();
            databaseService.StartCrawlTask();
        }
    }
}
