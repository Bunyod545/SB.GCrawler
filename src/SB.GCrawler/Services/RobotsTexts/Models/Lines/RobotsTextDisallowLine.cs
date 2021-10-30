using System;
namespace SB.GCrawler.Services.RobotsTexts
{
    /// <summary>
    /// 
    /// </summary>
    public class RobotsTextDisallowLine : RobotsTextLine
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
        public RobotsTextDisallowLine()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lineValue"></param>
        public RobotsTextDisallowLine(RobotsTextLineValue lineValue)
        {
            Url = lineValue.Value;
            Comment = lineValue.Comment;
        }
    }
}