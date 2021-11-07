using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SB.Auto.DependenyInjection;
using SB.GCrawler.Api.Contexts.MultiSchema;
using SB.GCrawler.Api.Services.Configs.Database;
using System;

namespace SB.GCrawler.Api.Contexts
{
    /// <summary>
    /// 
    /// </summary>
    [ScopedService]
    public partial class MultiSchemaDbContext : DbContext, IMultiSchemaDbContext
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IDatabaseConfigService _configService;

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string TableSchema { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configService"></param>
        public MultiSchemaDbContext(IDatabaseConfigService configService)
        {
            _configService = configService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configInfo = GetDbConfigInfo();
            optionsBuilder.UseNpgsql(configInfo.ConnectionString);

            optionsBuilder.ReplaceService<IHistoryRepository, MultiSchemaHistoryRepository>();
            optionsBuilder.ReplaceService<IMigrationsSqlGenerator, MultiSchemaMigrationsSqlGenerator>();
            optionsBuilder.ReplaceService<IModelCacheKeyFactory, MultiSchemaModelCacheKeyFactory>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DatabaseConfigInfo GetDbConfigInfo()
        {
            var config = _configService.GetDbConfig();
            if (config == null || string.IsNullOrEmpty(config.Provider) || string.IsNullOrEmpty(config.ConnectionString))
                throw new Exception("Database not configured");

            return config;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.SetTablesSchema(modelBuilder);
        }
    }
}
