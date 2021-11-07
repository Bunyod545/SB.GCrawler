namespace SB.GCrawler.Api.Services.Database
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDatabaseService
    {
        /// <summary>
        /// 
        /// </summary>
        void MigrateDatabase();

        /// <summary>
        /// 
        /// </summary>
        void MigrateMultiSchemas(); 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteId"></param>
        void MigrateMultiSchema(long siteId);
    }
}