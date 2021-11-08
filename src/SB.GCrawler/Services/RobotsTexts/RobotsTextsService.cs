using SB.Auto.DependenyInjection;
using SB.GCrawler.Services.FileDownloaders;
using System;
using System.Text;

namespace SB.GCrawler.Services.RobotsTexts
{
    /// <summary>
    /// 
    /// </summary>
    [ScopedService]
    public class RobotsTextsService : IRobotsTextsService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IFileDownloader _fileDownloader;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileDownloader"></param>
        public RobotsTextsService(IFileDownloader fileDownloader)
        {
            _fileDownloader = fileDownloader;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public RobotsTextFile Download(string url)
        {
            var fileUrl = new Uri(url);
            if (!fileUrl.PathAndQuery.EndsWith(RobotsTextConsts.RobotsTextFileName))
                fileUrl = new Uri(fileUrl, RobotsTextConsts.RobotsTextFileName);

            var fileBytes = _fileDownloader.DownloadFile(fileUrl.ToString());
            if (fileBytes == null)
                return null;

            return Parse(Encoding.UTF8.GetString(fileBytes));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public RobotsTextFile Parse(string content)
        {
            return new RobotsTextsHelpers().Parse(content);
        }
    }
}