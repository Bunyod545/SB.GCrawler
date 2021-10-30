using System.Collections.Generic;
namespace SB.GCrawler.Services.RobotsTexts
{
    /// <summary>
    /// 
    /// </summary>
    public class RobotsTextUserAgent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string AgentName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public List<RobotsTextRule> Rules { get; set; }
    }
}