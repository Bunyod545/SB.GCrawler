namespace SB.GCrawler.Services.RobotsTexts
{
    /// <summary>
    /// 
    /// </summary>
    public class RobotsTextSiteMapLine : RobotsTextLine
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Comment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RobotsTextSiteMapLine()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lineValue"></param>
        public RobotsTextSiteMapLine(RobotsTextLineValue lineValue)
        {
            Url = lineValue.Value;
            Comment = lineValue.Comment;
        }
    }
}