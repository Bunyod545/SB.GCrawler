using Microsoft.Extensions.DependencyInjection;
using SB.Auto.DependenyInjection;
using SB.GCrawler.Api.Contexts;
using SB.GCrawler.Api.Contexts.Tables;
using SB.GCrawler.Repositories.SiteMaps;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SB.GCrawler.Api.Repositories.SiteMaps
{
    /// <summary>
    /// 
    /// </summary>
    [ScopedService]
    public class SiteMapsRepository : ISiteMapsRepository
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IServiceScopeFactory _serviceScopeFactory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceScopeFactory"></param>
        public SiteMapsRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="siteMapUrls"></param>
        public void TryAddRange(long siteId, List<string> siteMapUrls)
        {
            if (siteMapUrls == null || siteMapUrls.Count == 0)
                return;

            var context = _serviceScopeFactory.CreateContext(siteId);
            var siteMaps = context.SiteMaps.ToList();

            foreach (var siteMapUrl in siteMapUrls)
            {
                if (siteMaps.Any(a => a.FileUrl == siteMapUrl))
                    continue;

                var siteMap = new GCrawlerSiteMap();
                siteMap.FileUrl = siteMapUrl;
                siteMap.SiteId = siteId;

                context.SiteMaps.Add(siteMap);
            }

            context.SaveChanges();
            context.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="siteId"></param>
        /// <returns></returns>
        public List<SiteMapCrawlInfo> GetSiteMaps(long siteId)
        {
            var context = _serviceScopeFactory.CreateContext(siteId);
            var siteMaps = context.SiteMaps.ToList();

            return siteMaps.Select(s => new SiteMapCrawlInfo(s.FileUrl)).ToList();
        }
    }
}
