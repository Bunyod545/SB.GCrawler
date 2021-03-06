using System.ComponentModel.DataAnnotations.Schema;

namespace SB.GCrawler.Api.Contexts.Tables
{
    /// <summary>
    /// 
    /// </summary>
    [Table("users", Schema = "public")]
    public class GCrawlerUser
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("fullname")]
        public string Fullname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("login")]
        public string Login { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("password_hash")]
        public string PasswordHash { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("password_salt")]
        public string PasswordSalt { get; set; }
    }
}
