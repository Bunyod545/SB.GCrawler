namespace SB.GCrawler.Services.RobotsTexts
{
    /// <summary>
    /// 
    /// </summary>
    public class RobotsTextUserAgentLine : RobotsTextLine
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Comment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RobotsTextUserAgentLine()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lineValue"></param>
        public RobotsTextUserAgentLine(RobotsTextLineValue lineValue) : this(lineValue.Value, lineValue.Comment)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public RobotsTextUserAgentLine(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        public RobotsTextUserAgentLine(string name, string comment) : this(name)
        {
            Comment = comment;
        }
    }
}