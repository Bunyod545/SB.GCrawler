using System.Collections.Generic;
using System.Linq;

namespace SB.GCrawler.Services.RobotsTexts
{
    /// <summary>
    /// 
    /// </summary>
    public class RobotsTextsUserAgentHelpers
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly List<RobotsTextLine> _lines;

        /// <summary>
        /// 
        /// </summary>
        private List<RobotsTextRule> _rules;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lines"></param>
        public RobotsTextsUserAgentHelpers(List<RobotsTextLine> lines)
        {
            _lines = lines;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAgentLine"></param>
        /// <returns></returns>
        public RobotsTextUserAgent GetUserAgent(RobotsTextUserAgentLine userAgentLine)
        {
            _rules = new List<RobotsTextRule>();

            var nextLines = _lines.Skip(userAgentLine.LineNumber).ToList();
            nextLines.ForEach(WalkNextLine);

            var agent = new RobotsTextUserAgent();
            agent.AgentName = userAgentLine.Name;
            agent.Rules = _rules;

            return agent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        private void WalkNextLine(RobotsTextLine line, IterateContext iterateContext)
        {
            if (line is RobotsTextEmptyLine)
                return;

            if (line is RobotsTextCommentLine)
                return;

            if (IsCombineUserAgent(line))
                return;

            if (line is RobotsTextAllowLine allowLine)
            {
                _rules.Add(new RobotsTextRule(allowLine));
                return;
            }

            if (line is RobotsTextDisallowLine disallowLine)
            {
                _rules.Add(new RobotsTextRule(disallowLine));
                return;
            }

            if (line is RobotsTextUnknownLine)
            {
                iterateContext.Break();
                return;
            }

            if (line is RobotsTextSiteMapLine)
            {
                iterateContext.Break();
                return;
            }

            if (line is RobotsTextUserAgentLine)
            {
                iterateContext.Break();
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        private bool IsCombineUserAgent(RobotsTextLine line)
        {
            return line is RobotsTextUserAgentLine &&
                   _rules.Count == 0;
        }
    }
}