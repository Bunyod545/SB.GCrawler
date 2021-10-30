namespace SB.GCrawler.Services.RobotsTexts
{
    /// <summary>
    /// 
    /// </summary>
    public class RobotsTextUnknownLine : RobotsTextLine
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public RobotsTextUnknownLine(string text)
        {
            Text = text;
        }

        /// <summary>
        /// 
        /// </summary>
        public RobotsTextUnknownLine()
        {

        }
    }
}