using System.ComponentModel.DataAnnotations.Schema;

namespace SB.GCrawler.Api.Contexts.Tables
{
    /// <summary>
    /// 
    /// </summary>
    [Table("site_robots")]
    public class GCrawlerSiteRobots
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("type")]
        public GCrawlerSiteRobotsType Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("value")]
        public string Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("site_id")]
        public long SiteId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey(nameof(SiteId))]
        public virtual GCrawlerSite Site { get; set; }
    }
}
