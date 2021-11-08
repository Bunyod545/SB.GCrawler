using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SB.GCrawler.Api.Contexts.Tables
{
    /// <summary>
    /// 
    /// </summary>
    [Table("sites", Schema = "public")]
    public class GCrawlerSite
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
        public DateTime? LastCrawlDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? RobotsFileLastUpdateDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey(nameof(UserId))]
        public virtual GCrawlerUser User { get; set; }
    }
}
