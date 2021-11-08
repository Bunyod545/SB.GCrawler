using System;
using System.Collections.Generic;
using System.Linq;

namespace SB.GCrawler.Services.RobotsTexts
{
    /// <summary>
    /// 
    /// </summary>
    public class RobotsTextsHelpers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public RobotsTextFile Parse(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                return new RobotsTextFile();

            var lines = ParseLines(content);
            var file = new RobotsTextFile();

            file.SiteMaps = GetSiteMapsFromLines(lines);
            file.UserAgents = GetUserAgentsFromLines(lines);
            return file;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public List<RobotsTextLine> ParseLines(string content)
        {
            var lineTexts = content.Split(new string[] { RobotsTextConsts.NewLine }, StringSplitOptions.None);
            var lineHelper = new RobotsTextsLineHelper();

            return lineTexts.Select((s, i) => lineHelper.ParseLine(s, i)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        private List<RobotsTextSiteMap> GetSiteMapsFromLines(List<RobotsTextLine> lines)
        {
            var sitemaps = lines.OfType<RobotsTextSiteMapLine>().ToList();
            return sitemaps.Select(s => new RobotsTextSiteMap(s.Url, s.Comment)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        private List<RobotsTextUserAgent> GetUserAgentsFromLines(List<RobotsTextLine> lines)
        {
            var userAgents = lines.OfType<RobotsTextUserAgentLine>().ToList();
            var agents = userAgents.Select(s => GetUserAgent(s, lines)).ToList();

            return CombineEqualUserAgents(agents);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="agentLine"></param>
        /// <param name="lines"></param>
        /// <returns></returns>
        private RobotsTextUserAgent GetUserAgent(RobotsTextUserAgentLine agentLine, List<RobotsTextLine> lines)
        {
            var helper = new RobotsTextsUserAgentHelpers(lines);
            return helper.GetUserAgent(agentLine);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAgents"></param>
        /// <returns></returns>
        private List<RobotsTextUserAgent> CombineEqualUserAgents(List<RobotsTextUserAgent> userAgents)
        {
            var resultAgents = new List<RobotsTextUserAgent>();
            userAgents.ForEach(f => CombineEqualUserAgent(resultAgents, f));

            return resultAgents;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultAgents"></param>
        /// <param name="agent"></param>
        private void CombineEqualUserAgent(List<RobotsTextUserAgent> resultAgents, RobotsTextUserAgent agent)
        {
            var existsAgent = resultAgents.FirstOrDefault(f => f.AgentName == agent.AgentName);
            if (existsAgent == null)
            {
                resultAgents.Add(agent);
                return;
            }

            existsAgent.Rules.AddRange(agent.Rules);
        }
    }
}