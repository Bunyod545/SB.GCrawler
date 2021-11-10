using SB.Auto.DependenyInjection;
using SB.GCrawler.Crawlers.SiteMapsCrawler;
using SB.GCrawler.Crawlers.SitePageCrawler;
using SB.GCrawler.Services.RobotsTexts;

namespace SB.GCrawler.Crawlers.SiteCrawler
{
    /// <summary>
    /// 
    /// </summary>
    [ScopedService]
    public class SiteCrawlerService : ISiteCrawlerService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IRobotsTextsService _robotsTextsService;

        /// <summary>
        /// 
        /// </summary>
        private readonly ISiteMapsCrawlerService _siteMapCrawlerService;

        /// <summary>
        /// 
        /// </summary>
        private readonly ISitePagesCrawlerService _sitePagesCrawlerService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="robotsTextsService"></param>
        /// <param name="siteMapCrawlerService"></param>
        /// <param name="sitePagesCrawlerService"></param>
        public SiteCrawlerService(IRobotsTextsService robotsTextsService, ISiteMapsCrawlerService siteMapCrawlerService, ISitePagesCrawlerService sitePagesCrawlerService)
        {
            _robotsTextsService = robotsTextsService;
            _siteMapCrawlerService = siteMapCrawlerService;
            _sitePagesCrawlerService = sitePagesCrawlerService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public void Crawl(SiteCrawlArgs args)
        {
            var crawlContext = new CrawlContext();
            crawlContext.SiteId = args.SiteId;
            crawlContext.Url = args.Url;
            crawlContext.RobotsTextFile = _robotsTextsService.Download(args.Url);

            _siteMapCrawlerService.Crawl(crawlContext);
            _sitePagesCrawlerService.Crawl(crawlContext);
        }
    }
}
