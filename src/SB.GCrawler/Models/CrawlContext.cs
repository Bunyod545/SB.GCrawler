using SB.GCrawler.Services.RobotsTexts;

namespace SB.GCrawler
{
    /// <summary>
    /// 
    /// </summary>
    public class CrawlContext
    {
        /// <summary>
        /// 
        /// </summary>
        public long SiteId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RobotsTextFile RobotsTextFile { get; set; }
    }
}
