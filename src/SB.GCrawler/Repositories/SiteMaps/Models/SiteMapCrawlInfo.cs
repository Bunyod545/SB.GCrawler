namespace SB.GCrawler.Repositories.SiteMaps
{
    /// <summary>
    /// 
    /// </summary>
    public class SiteMapCrawlInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public SiteMapCrawlInfo(string url)
        {
            Url = url;
        }
    }
}
