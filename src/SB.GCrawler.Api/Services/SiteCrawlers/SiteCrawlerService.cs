using SB.Auto.DependenyInjection;
using SB.GCrawler.Api.Contexts;
using SB.GCrawler.Api.Contexts.Tables;
using SB.GCrawler.Api.Services.RobotsTexts;
using SB.GCrawler.Services.FileDownloaders;
using SB.GCrawler.Services.RobotsTexts;
using System.Linq;

namespace SB.GCrawler.Api.Services.SiteCrawlers
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
        private readonly CommonDbContext _context;

        /// <summary>
        /// 
        /// </summary>
        private readonly IRobotsTextsService _robotsTextsService;

        /// <summary>
        /// 
        /// </summary>
        private readonly IFileDownloader _fileDownloader;

        /// <summary>
        /// 
        /// </summary>
        private readonly IRobotsTextsRepository _robotsTextsRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="robotsTextsService"></param>
        /// <param name="robotsTextsRepository"></param>
        public SiteCrawlerService(CommonDbContext context, IRobotsTextsService robotsTextsService, IFileDownloader fileDownloader, IRobotsTextsRepository robotsTextsRepository)
        {
            _context = context;
            _robotsTextsService = robotsTextsService;
            _fileDownloader = fileDownloader;
            _robotsTextsRepository = robotsTextsRepository;
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
            var fileUrl = site.GetRobotsTextUri();
            var robotsFileInfo = _fileDownloader.GetFileInfo(fileUrl);
            var robotsTextFile = _robotsTextsService.Download(fileUrl);

            _robotsTextsRepository.SaveRobotsFile(site, robotsTextFile);
            
            var robotsTextFileContent = _robotsTextsRepository.GetRobotsFile(site);
            robotsTextFile = _robotsTextsService.Parse(robotsTextFileContent);
        }
    }
}
