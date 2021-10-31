using System.IO;
using System.Linq;
using System;
using System.Collections.Generic;

namespace SB.GCrawler.Services.RobotsTexts
{
    /// <summary>
    /// 
    /// </summary>
    public class RobotsTextFile
    {
        /// <summary>
        /// 
        /// </summary>
        private RobotsTextsAccessHelper _accessHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string BaseUrl { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public List<RobotsTextUserAgent> UserAgents { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public List<RobotsTextSiteMap> SiteMaps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RobotsTextFile(string baseUrl) : this()
        {
            this.BaseUrl = baseUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        public RobotsTextFile()
        {
            _accessHelper = new RobotsTextsAccessHelper();
            UserAgents = new List<RobotsTextUserAgent>();
            SiteMaps = new List<RobotsTextSiteMap>();
        }

        /// <summary>
        /// 
        /// /// </summary>
        /// <param name="baseUrl"></param>
        public void SetBaseUrl(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool IsAllow(string userAgent, string url)
        {
            if (url == null)
                return false;

            return IsAllow(userAgent, new Uri(url));
        }

        /// <summary>
        /// 
        /// /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public bool IsAllow(string userAgent, Uri uri)
        {
            if (!uri.IsAbsoluteUri)
                uri = new Uri(new Uri(BaseUrl), uri);

            var agent = UserAgents.FirstOrDefault(f => f.AgentName == userAgent);
            agent = agent ?? UserAgents.FirstOrDefault(f => f.AgentName == "*");

            return _accessHelper.IsAllowed(agent, uri);
        }
    }
}