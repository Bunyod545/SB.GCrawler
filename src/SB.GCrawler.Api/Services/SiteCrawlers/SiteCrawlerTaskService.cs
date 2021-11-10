using SB.Auto.DependenyInjection;
using SB.GCrawler.Api.Contexts;
using SB.GCrawler.Api.Contexts.Tables;
using SB.GCrawler.Crawlers.SiteCrawler;
using System.Linq;

namespace SB.GCrawler.Api.Services.SiteCrawlers
{
    /// <summary>
    /// 
    /// </summary>
    [ScopedService]
    public class SiteCrawlerTaskService : ISiteCrawlerTaskService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly CommonDbContext _context;

        /// <summary>
        /// 
        /// </summary>
        private readonly ISiteCrawlerService _siteCrawlerService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="siteCrawlerService"></param>
        public SiteCrawlerTaskService(CommonDbContext context, ISiteCrawlerService siteCrawlerService)
        {
            _context = context;
            _siteCrawlerService = siteCrawlerService;
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartCrawlTask()
        {
            var sites = _context.Sites.ToList();
            sites.ForEach(CrawlSite);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void CrawlSite(GCrawlerSite site)
        {
            var crawlArgs = new SiteCrawlArgs();
            crawlArgs.SiteId = site.Id;
            crawlArgs.Url = site.Url;

            _siteCrawlerService.Crawl(crawlArgs);
        }
    }
}
