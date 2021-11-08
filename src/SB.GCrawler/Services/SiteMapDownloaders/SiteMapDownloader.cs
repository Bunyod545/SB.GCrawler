using SB.Auto.DependenyInjection;
using SB.GCrawler.Services.FileDownloaders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace SB.GCrawler.Services.SiteMapDownloaders
{
    /// <summary>
    /// 
    /// </summary>
    [ScopedService]
    public class SiteMapDownloader : ISiteMapDownloader
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IFileDownloader _fileDownloader;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileDownloader"></param>
        public SiteMapDownloader(IFileDownloader fileDownloader)
        {
            _fileDownloader = fileDownloader;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public SiteMapInfo GetSiteMapInfo(string url)
        {
            try
            {
                return TryGetSiteMapInfo(url);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private SiteMapInfo TryGetSiteMapInfo(string url)
        {
            var fileBytes = _fileDownloader.DownloadFile(url);
            if (fileBytes == null)
                return null;

            var memoryStream = new MemoryStream(fileBytes);
            var xmlReader = new XmlTextReader(memoryStream);
            xmlReader.Namespaces = false;

            var serializer = new XmlSerializer(typeof(SiteMapUrlSet));
            var urlSet = (SiteMapUrlSet)serializer.Deserialize(xmlReader);
            memoryStream.Dispose();

            var infos = ConvertUrlSetToInfo(urlSet);
            if (infos == null)
                return null;

            var result = new SiteMapInfo();
            result.Items = infos;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="urlSet"></param>
        /// <returns></returns>
        private List<SiteMapItemInfo> ConvertUrlSetToInfo(SiteMapUrlSet urlSet)
        {
            if (urlSet?.Urls == null)
                return null;

            return urlSet.Urls.Select(s => ConvertToUrlInfo(s)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private SiteMapItemInfo ConvertToUrlInfo(SiteMapUrl url)
        {
            var urlInfo = new SiteMapItemInfo();
            urlInfo.Url = url.LocactionUrl;
            urlInfo.LastModified = url.LastModified;

            return urlInfo;
        }
    }
}
