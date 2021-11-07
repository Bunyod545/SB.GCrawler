using System.ComponentModel.DataAnnotations.Schema;

namespace SB.GCrawler.Api.Contexts.Tables
{
    /// <summary>
    /// 
    /// </summary>
    [Table("user_tokens", Schema = "public")]
    public class GCrawlerUserToken
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

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
