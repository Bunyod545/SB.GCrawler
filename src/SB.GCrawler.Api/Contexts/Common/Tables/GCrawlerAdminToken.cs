using System.ComponentModel.DataAnnotations.Schema;

namespace SB.GCrawler.Api.Contexts.Tables
{
    /// <summary>
    /// 
    /// </summary>
    [Table("admin_tokens")]
    public class GCrawlerAdminToken
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("admin_id")]
        public long AdminId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey(nameof(AdminId))]
        public GCrawlerAdmin User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("token")]
        public string Token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
