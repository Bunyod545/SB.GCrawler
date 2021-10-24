using Microsoft.EntityFrameworkCore;
using SB.GCrawler.Api.Contexts.Tables;

namespace SB.GCrawler.Api.Contexts
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MultiSchemaContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<GCrawlerSiteMap> SiteMaps { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DbSet<GCrawlerSitePage> SitePages { get; set; }
    }
}
