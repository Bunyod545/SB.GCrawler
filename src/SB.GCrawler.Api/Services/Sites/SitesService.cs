using System.Linq;
using SB.Auto.DependenyInjection;
using SB.GCrawler.Api.Contexts;
using SB.GCrawler.Api.Contexts.Tables;
using SB.GCrawler.Api.Services.CurrentUser;
using SB.GCrawler.Api.Services.Database;

namespace SB.GCrawler.Api.Services.Sites
{
    /// <summary>
    /// 
    /// </summary>
    [ScopedService]
    public class SitesService : ISitesService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ICurrentUserService _currentUserService;

        /// <summary>
        /// 
        /// </summary>
        private readonly IDatabaseService _databaseService;

        /// <summary>
        /// 
        /// </summary>
        private readonly CommonDbContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentUserService"></param>
        /// <param name="context"></param>
        public SitesService(ICurrentUserService currentUserService, IDatabaseService databaseService, CommonDbContext context)
        {
            _currentUserService = currentUserService;
            _databaseService = databaseService;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public SiteCreateResult Create(SiteCreateArgs args)
        {
            if (string.IsNullOrWhiteSpace(args?.Url))
                return null;

            var userId = _currentUserService.GetCurrentUserId();
            if (userId == null)
                return null;

            var site = _context.Sites.FirstOrDefault(f => f.Url == args.Url);
            if (site != null)
                return null;

            site = new GCrawlerSite();
            site.Url = args.Url;
            site.UserId = userId.Value;

            _context.Sites.Add(site);
            _context.SaveChanges();

            _databaseService.MigrateMultiSchemaAsync(site.Id);
            return new SiteCreateResult(site.Id);
        }
    }
}