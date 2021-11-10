using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using SB.Auto.DependenyInjection;
using SB.GCrawler.Api.Contexts.MultiSchema;
using SB.GCrawler.Api.Contexts.MultiSchema.Helpers;
using SB.GCrawler.Api.Contexts.Tables;
using SB.GCrawler.Api.Services;
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
        private readonly ICurrentSchemaService _currentSchemaService;

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string TableSchema { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configService"></param>
        /// <param name="currentSchemaService"></param>
        public MultiSchemaDbContext(IDatabaseConfigService configService, ICurrentSchemaService currentSchemaService)
        {
            _configService = configService;
            _currentSchemaService = currentSchemaService;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetCurrentSchema()
        {
            TableSchema = _currentSchemaService.GetCurrentSchema();
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetSiteSchema(long siteId)
        {
            TableSchema = string.Format(MultiSchemaHelper.SchemaTemplate, siteId);
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
