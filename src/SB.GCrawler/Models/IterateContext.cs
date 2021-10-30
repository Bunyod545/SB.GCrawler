using System;

namespace SB.GCrawler
{
    /// <summary>
    /// 
    /// </summary>
    public class IterateContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public bool IsBreak { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public long Index { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void Break()
        {
            IsBreak = true;
        }
    }
}