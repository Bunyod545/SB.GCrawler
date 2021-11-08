using SB.GCrawler.Api.Contexts.Tables;
using SB.GCrawler.Services.RobotsTexts;
using System;

namespace SB.GCrawler.Api
{
    /// <summary>
    /// 
    /// </summary>
    public static class GCrawlerSiteExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        public static string GetRobotsTextUri(this GCrawlerSite site)
        {
            return new Uri(new Uri(site.Url), RobotsTextConsts.RobotsTextFileName).ToString();
        }
    }
}
