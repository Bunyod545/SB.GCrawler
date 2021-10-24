using System.ComponentModel.DataAnnotations.Schema;

namespace SB.GCrawler.Api.Contexts.Tables
{
    /// <summary>
    /// 
    /// </summary>
    [Table("site_pages")]
    public class GCrawlerSitePage
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("url")]
        public string Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey(nameof(UserId))]
        public GCrawlerUser User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("site_id")]
        public long SiteId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey(nameof(Site))]
        public GCrawlerSite Site { get; set; }
    }
}
