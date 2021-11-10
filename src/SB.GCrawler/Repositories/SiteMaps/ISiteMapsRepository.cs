using System.Collections.Generic;

namespace SB.GCrawler.Repositories.SiteMaps
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISiteMapsRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="siteMapUrls"></param>
        void TryAddRange(long siteId, List<string> siteMapUrls);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteId"></param>
        /// <returns></returns>
        List<SiteMapCrawlInfo> GetSiteMaps(long siteId);
    }
}
