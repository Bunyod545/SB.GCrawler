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
        bool IsValidConnectionString(DatabaseConfigInfo config);
    }
}
