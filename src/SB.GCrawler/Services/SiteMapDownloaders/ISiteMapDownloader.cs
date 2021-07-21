namespace SB.GCrawler.Services.SiteMapDownloaders
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISiteMapDownloader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        SiteMapInfo GetSiteMapInfo(string url);
    }
}
