using System;
using System.Xml.Serialization;

namespace SB.GCrawler.Services.SiteMapDownloaders
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot(ElementName = "url")]
    public class SiteMapUrl
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "loc")]
        public string LocactionUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "lastmod")]
        public DateTime LastModified { get; set; }
    }
}
