using SB.GCrawler.Services.RobotsTexts;

namespace SB.GCrawler.Repositories.RobotsTexts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRobotsTextsRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="robotsTextFile"></param>
        void SaveRobotsFile(long siteId, RobotsTextFile robotsTextFile);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteId"></param>
        /// <returns></returns>
        string GetRobotsFile(long siteId);
    }
}
