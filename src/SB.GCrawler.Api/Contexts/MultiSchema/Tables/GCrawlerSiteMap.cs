using System.ComponentModel.DataAnnotations.Schema;

namespace SB.GCrawler.Api.Contexts.Tables
{
    /// <summary>
    /// 
    /// </summary>
    [Table("site_maps")]
    public class GCrawlerSiteMap
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("file_url")]
        public string FileUrl { get; set; }

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
