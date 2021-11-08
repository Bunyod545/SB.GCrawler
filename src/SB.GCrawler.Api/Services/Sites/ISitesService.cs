namespace SB.GCrawler.Api.Services.Sites
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISitesService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        SiteCreateResult Create(SiteCreateArgs args);
    }
}