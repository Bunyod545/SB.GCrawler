using SB.Auto.DependenyInjection;
using SB.GCrawler.Repositories.SiteMaps;
using System.Linq;

namespace SB.GCrawler.Crawlers.SiteMapsCrawler
{
    /// <summary>
    /// 
    /// </summary>
    [ScopedService]
    public class SiteMapsCrawlerService : ISiteMapsCrawlerService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ISiteMapsRepository _siteMapsRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteMapsRepository"></param>
        public SiteMapsCrawlerService(ISiteMapsRepository siteMapsRepository)
        {
            _siteMapsRepository = siteMapsRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="crawlContext"></param>
        public void Crawl(CrawlContext crawlContext)
        {
            SaveSiteMaps(crawlContext);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="crawlContext"></param>
        private void SaveSiteMaps(CrawlContext crawlContext)
        {
            var siteMaps = crawlContext.RobotsTextFile?.SiteMaps;
            if (siteMaps == null)
                return;

            var siteMapUrls = siteMaps.Select(s => s.Url).ToList();
            _siteMapsRepository.TryAddRange(crawlContext.SiteId, siteMapUrls);
        }
    }
}
