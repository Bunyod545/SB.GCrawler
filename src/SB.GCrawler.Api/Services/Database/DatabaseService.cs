using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SB.Auto.DependenyInjection;
using SB.GCrawler.Api.Contexts;
using SB.GCrawler.Api.Contexts.MultiSchema.Helpers;
using SB.GCrawler.Api.Services.Configs.Database;

namespace SB.GCrawler.Api.Services.Database
{
    /// <summary>
    /// 
    /// </summary>
    [ScopedService]
    public class DatabaseService : IDatabaseService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IDatabaseConfigService _databaseConfigService;

        /// <summary>
        /// 
        /// </summary>
        private readonly IServiceScopeFactory _serviceScopeFactory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commonContext"></param>
        public DatabaseService(IDatabaseConfigService databaseConfigService, IServiceScopeFactory serviceScopeFactory)
        {
            _databaseConfigService = databaseConfigService;
            _serviceScopeFactory = serviceScopeFactory;
        }

        /// <summary>
        /// 
        /// </summary>
        public void MigrateDatabase()
        {
            var config = _databaseConfigService.GetDbConfig();
            if (config == null)
                return;

            using var scope = _serviceScopeFactory.CreateScope();
            using var context = scope.ServiceProvider.GetService<CommonDbContext>();

            context.Database.Migrate();
            MigrateMultiSchemas();
        }

        /// <summary>
        /// 
        /// </summary>
        public void MigrateMultiSchemas()
        {
            var config = _databaseConfigService.GetDbConfig();
            if (config == null)
                return;

            using var scope = _serviceScopeFactory.CreateScope();
            using var context = scope.ServiceProvider.GetService<CommonDbContext>();

            var sites = context.Sites.Select(s => s.Id).OrderBy(o => o).ToList();
            var options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 2;

            Parallel.ForEach(sites, options, MigrateMultiSchema);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteId"></param>
        public Task MigrateMultiSchemaAsync(long siteId)
        {
            return Task.Run(() => MigrateMultiSchema(siteId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteId"></param>
        public void MigrateMultiSchema(long siteId)
        {
            var config = _databaseConfigService.GetDbConfig();
            if (config == null)
                return;

            using var scope = _serviceScopeFactory.CreateScope();
            using var context = scope.ServiceProvider.GetService<MultiSchemaDbContext>();

            context.TableSchema = string.Format(MultiSchemaHelper.SchemaTemplate, siteId);
            context.Database.Migrate();
        }
    }
}