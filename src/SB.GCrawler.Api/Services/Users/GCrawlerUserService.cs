using SB.Auto.DependenyInjection;
using SB.GCrawler.Api.Contexts;
using System.Linq;

namespace SB.GCrawler.Api.Services.Users
{
    /// <summary>
    /// 
    /// </summary>
    [ScopedService]
    public class GCrawlerUserService : IGCrawlerUserService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly GCrawlerContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public GCrawlerUserService(GCrawlerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool AnyUserExists()
        {
            return _context.Users.Count() > 0;
        }
    }
}