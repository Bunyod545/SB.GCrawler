using Npgsql;
using SB.Auto.DependenyInjection;
using System;
using System.Data;

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
    }
}
