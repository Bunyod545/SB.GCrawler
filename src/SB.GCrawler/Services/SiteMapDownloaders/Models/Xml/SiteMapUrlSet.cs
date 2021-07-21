using System.Collections.Generic;
using System.Xml.Serialization;

namespace SB.GCrawler.Services.SiteMapDownloaders
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot(ElementName = "urlset")]
    public class SiteMapUrlSet
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "url")]
        public List<SiteMapUrl> Urls { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }
}
