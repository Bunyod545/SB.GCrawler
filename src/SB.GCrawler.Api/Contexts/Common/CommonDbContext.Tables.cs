using Microsoft.EntityFrameworkCore;
using SB.GCrawler.Api.Contexts.Tables;

namespace SB.GCrawler.Api.Contexts
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CommonDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<GCrawlerUser> Users { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<GCrawlerUserToken> UserTokens { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<GCrawlerSite> Sites { get; set; }
    }
}
