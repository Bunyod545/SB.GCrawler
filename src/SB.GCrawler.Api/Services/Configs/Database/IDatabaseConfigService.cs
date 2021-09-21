namespace SB.GCrawler.Api.Services.Configs.Database
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDatabaseConfigService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        bool ValidateAndSave(DatabaseConfigInfo config);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        bool IsValidConnectionString(DatabaseConfigInfo config);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        bool SaveDbConfig(DatabaseConfigInfo config);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DatabaseConfigInfo GetDbConfig();
    }
}
