using Microsoft.EntityFrameworkCore;
using SB.Auto.DependenyInjection;
using SB.GCrawler.Api.Services.Configs.Database;
using System;

namespace SB.GCrawler.Api.Contexts
{
    /// <summary>
    /// 
    /// </summary>
    [ScopedService]
    public partial class MultiSchemaContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IDatabaseConfigService _configService;

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Schema { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configService"></param>
        public MultiSchemaContext(IDatabaseConfigService configService)
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
    }
}
