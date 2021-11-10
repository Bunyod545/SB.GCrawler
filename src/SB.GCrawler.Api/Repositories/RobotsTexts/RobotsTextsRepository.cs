using Microsoft.Extensions.DependencyInjection;
using SB.Auto.DependenyInjection;
using SB.GCrawler.Api.Contexts.Tables;
using SB.GCrawler.Repositories.RobotsTexts;
using SB.GCrawler.Services.RobotsTexts;
using System.Collections.Generic;
using System.Linq;

namespace SB.GCrawler.Api.Services.RobotsTexts
{
    /// <summary>
    /// 
    /// </summary>
    [ScopedService]
    public class RobotsTextsRepository : IRobotsTextsRepository
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IServiceScopeFactory _serviceScopeFactory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public RobotsTextsRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="robotsTextFile"></param>
        public void SaveRobotsFile(long siteId, RobotsTextFile robotsTextFile)
        {
            var context = _serviceScopeFactory.CreateContext(siteId);
            var robotsTexts = context.SiteRobots.ToList();
            context.SiteRobots.RemoveRange(robotsTexts);

            var rules = robotsTextFile.UserAgents.SelectMany(s => ConvertUserAgentToDbInfo(siteId, s)).ToList();
            var sitemaps = robotsTextFile.SiteMaps.Select(s => ConvertSiteMapToDbInfo(siteId, s)).ToList();

            context.SiteRobots.AddRange(rules);
            context.SiteRobots.AddRange(sitemaps);
            context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="userAgent"></param>
        /// <returns></returns>
        private List<GCrawlerSiteRobots> ConvertUserAgentToDbInfo(long siteId, RobotsTextUserAgent userAgent)
        {
            var dbAgent = new GCrawlerSiteRobots();
            dbAgent.Type = GCrawlerSiteRobotsType.Agent;
            dbAgent.SiteId = siteId;
            dbAgent.Value = userAgent.AgentName;
            dbAgent.Comment = userAgent.Comment;

            var result = new List<GCrawlerSiteRobots>();
            result.Add(dbAgent);

            var rules = userAgent.Rules.Select(s => ConvertAccessToDbInfo(siteId, s)).ToList();
            result.AddRange(rules);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        private GCrawlerSiteRobots ConvertAccessToDbInfo(long siteId, RobotsTextRule rule)
        {
            var dbRule = new GCrawlerSiteRobots();
            dbRule.Value = rule.Url;
            dbRule.Comment = rule.Comment;
            dbRule.SiteId = siteId;

            if (rule.RuleType == RobotsTextRuleType.Allow)
                dbRule.Type = GCrawlerSiteRobotsType.Allow;

            if (rule.RuleType == RobotsTextRuleType.Disallow)
                dbRule.Type = GCrawlerSiteRobotsType.Disallow;

            return dbRule;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="siteMap"></param>
        /// <returns></returns>
        private GCrawlerSiteRobots ConvertSiteMapToDbInfo(long siteId, RobotsTextSiteMap siteMap)
        {
            var dbSiteMap = new GCrawlerSiteRobots();
            dbSiteMap.Type = GCrawlerSiteRobotsType.SiteMap;
            dbSiteMap.Value = siteMap.Url;
            dbSiteMap.Comment = siteMap.Comment;
            dbSiteMap.SiteId = siteId;

            return dbSiteMap;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteId"></param>
        /// <returns></returns>
        public string GetRobotsFile(long siteId)
        {
            var context = _serviceScopeFactory.CreateContext(siteId);
            var robots = context.SiteRobots.ToList();
            var robotsText = robots.Select(GetRobotsTextLine).ToList();

            return string.Join(RobotsTextConsts.NewLine, robotsText);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="robotsLine"></param>
        /// <returns></returns>
        private string GetRobotsTextLine(GCrawlerSiteRobots robotsLine)
        {
            if (robotsLine.Type == GCrawlerSiteRobotsType.Agent)
                return ConvertRobotsTextLine(RobotsTextConsts.UserAgentKey, robotsLine);

            if (robotsLine.Type == GCrawlerSiteRobotsType.Allow)
                return ConvertRobotsTextLine(RobotsTextConsts.AllowKey, robotsLine);

            if (robotsLine.Type == GCrawlerSiteRobotsType.Disallow)
                return ConvertRobotsTextLine(RobotsTextConsts.DisallowKey, robotsLine);

            if (robotsLine.Type == GCrawlerSiteRobotsType.SiteMap)
                return ConvertRobotsTextLine(RobotsTextConsts.SiteMapKey, robotsLine);

            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="robotsLine"></param>
        /// <returns></returns>
        private string ConvertRobotsTextLine(string key, GCrawlerSiteRobots robotsLine)
        {
            return $"{key}: {robotsLine.Value}";
        }
    }
}
