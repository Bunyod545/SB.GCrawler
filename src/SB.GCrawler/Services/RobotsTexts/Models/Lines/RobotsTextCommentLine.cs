namespace SB.GCrawler.Services.RobotsTexts
{
    /// <summary>
    /// 
    /// </summary>
    public class RobotsTextCommentLine : RobotsTextLine
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Comment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comment"></param>
        public RobotsTextCommentLine(string comment)
        {
            Comment = comment;
        }

        /// <summary>
        /// 
        /// </summary>
        public RobotsTextCommentLine()
        {

        }
    }
}