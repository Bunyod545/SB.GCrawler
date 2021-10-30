namespace SB.GCrawler.Services.RobotsTexts
{
    /// <summary>
    /// 
    /// </summary>
    public class RobotsTextRule
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
        /// <value></value>
        public RobotsTextRuleType RuleType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RobotsTextRule()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="allowLine"></param>
        public RobotsTextRule(RobotsTextAllowLine allowLine)
        {
            Url = allowLine.Url;
            Comment = allowLine.Comment;
            RuleType = RobotsTextRuleType.Allow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disallowLine"></param>
        public RobotsTextRule(RobotsTextDisallowLine disallowLine)
        {
            Url = disallowLine.Url;
            Comment = disallowLine.Comment;
            RuleType = RobotsTextRuleType.Disallow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="comment"></param>
        public RobotsTextRule(string url, string comment = null)
        {
            Url = url;
            Comment = comment;
        }
    }
}