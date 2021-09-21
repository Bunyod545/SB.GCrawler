using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Npgsql;
using SB.Auto.DependenyInjection;
using SB.GCrawler.Api.Contexts;
using System;
using System.Data;
using File = System.IO.File;

namespace SB.GCrawler.Api.Services.Configs.Database
{
    /// <summary>
    /// 
    /// </summary>
    [ScopedService]
    public class DatabaseConfigService : IDatabaseConfigService
    {
        /// <summary>
        /// 
        /// </summary>
        public const string ConfigFile = "dbconfig.json";

        /// <summary>
        /// 
        /// </summary>
        private readonly IHostEnvironment _environment;

        /// <summary>
        /// 
        /// </summary>
        private readonly IServiceScopeFactory _serviceScopeFactory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="serviceScopeFactory"></param>
        public DatabaseConfigService(IHostEnvironment environment, IServiceScopeFactory serviceScopeFactory)
        {
            _environment = environment;
            _serviceScopeFactory = serviceScopeFactory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public bool ValidateAndSave(DatabaseConfigInfo config)
        {
            if (!IsValidConnectionString(config))
                return false;

            if (!SaveDbConfig(config))
                return false;

            var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<GCrawlerContext>();
            
            context.Database.Migrate();
            scope.Dispose();
            context.Dispose();

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public bool IsValidConnectionString(DatabaseConfigInfo config)
        {
            try
            {
                return TryIsValidConnectionString(config);
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public bool TryIsValidConnectionString(DatabaseConfigInfo config)
        {
            var conn = new NpgsqlConnection(config.ConnectionString);
            conn.Open();

            var state = conn.State;
            conn.Close();

            return state == ConnectionState.Open;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public bool SaveDbConfig(DatabaseConfigInfo config)
        {
            try
            {
                return TrySaveDbConfig(config);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        private bool TrySaveDbConfig(DatabaseConfigInfo config)
        {
            var configJson = JsonConvert.SerializeObject(config, Formatting.Indented);
            var physicalPath = GetConfigPath();

            File.WriteAllText(physicalPath, configJson);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DatabaseConfigInfo GetDbConfig()
        {
            try
            {
                return TryGetDbConfig();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DatabaseConfigInfo TryGetDbConfig()
        {
            var physicalPath = GetConfigPath();
            if (!File.Exists(physicalPath))
                return null;

            var configJson = File.ReadAllText(physicalPath);
            return JsonConvert.DeserializeObject<DatabaseConfigInfo>(configJson);
        }

        /// <summary>
        /// 
        /// </summary>
        public string GetConfigPath()
        {
            var fileProvider = _environment.ContentRootFileProvider;
            var fileInfo = fileProvider.GetFileInfo(ConfigFile);

            return fileInfo.PhysicalPath;
        }
    }
}
