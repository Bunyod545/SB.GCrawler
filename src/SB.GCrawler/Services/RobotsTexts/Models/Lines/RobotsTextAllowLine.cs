using System;
namespace SB.GCrawler.Services.RobotsTexts
{
    /// <summary>
    /// 
    /// </summary>
    public class RobotsTextAllowLine : RobotsTextLine
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
        public RobotsTextAllowLine()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lineValue"></param>
        public RobotsTextAllowLine(RobotsTextLineValue lineValue)
        {
            Url = lineValue.Value;
            Comment = lineValue.Comment;
        }
    }
}