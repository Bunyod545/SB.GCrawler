using SB.GCrawler.Api.Contexts.Tables;
using SB.GCrawler.Services.RobotsTexts;

namespace SB.GCrawler.Api.Services.RobotsTexts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRobotsTextsRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="site"></param>
        /// <param name="robotsTextFile"></param>
        void SaveRobotsFile(GCrawlerSite site, RobotsTextFile robotsTextFile);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        string GetRobotsFile(GCrawlerSite site);
    }
}
