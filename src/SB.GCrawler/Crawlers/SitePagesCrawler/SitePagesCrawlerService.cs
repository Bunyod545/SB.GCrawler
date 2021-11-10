using SB.Auto.DependenyInjection;

namespace SB.GCrawler.Crawlers.SitePageCrawler
{
    /// <summary>
    /// 
    /// </summary>
    [ScopedService]
    public class SitePagesCrawlerService : ISitePagesCrawlerService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void Crawl(CrawlContext context)
        {

        }
    }
}
