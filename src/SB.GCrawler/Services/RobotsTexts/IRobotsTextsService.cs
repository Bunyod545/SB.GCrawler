namespace SB.GCrawler.Services.RobotsTexts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRobotsTextsService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        RobotsTextFile Download(string url);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        RobotsTextFile Parse(string content);
    }
}