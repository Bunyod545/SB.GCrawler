namespace SB.GCrawler.Api.Services.Sites
{
    /// <summary>
    /// 
    /// </summary>
    public class SiteCreateResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SiteCreateResult(long id)
        {
            Id = id;
        }
    }
}