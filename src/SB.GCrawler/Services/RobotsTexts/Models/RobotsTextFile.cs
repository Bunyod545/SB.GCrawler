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
        /// /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public bool IsAllow(Uri uri)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool IsAllow(string url)
        {
            return false;
        }
    }
}