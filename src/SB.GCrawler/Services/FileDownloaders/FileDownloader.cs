using System;
using System.Net;

namespace SB.GCrawler.Services.FileDownloaders
{
    /// <summary>
    /// 
    /// </summary>
    public class FileDownloader : IFileDownloader
    {
        /// <summary>
        /// 
        /// </summary>
        public const string DownloadUserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:40.0) Gecko/20100101 Firefox/40.1";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public FileDownloadInfo GetFileInfo(string url)
        {
            try
            {
                return TryGetFileInfo(url);
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
        private FileDownloadInfo TryGetFileInfo(string url)
        {
            var request = WebRequest.CreateHttp(url);
            request.UserAgent = DownloadUserAgent;

            var response = (HttpWebResponse)request.GetResponseAsync().Result;
            var length = response.ContentLength;

            var result = new FileDownloadInfo();
            result.Size = length;

            response.Dispose();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public byte[] DownloadFile(string url)
        {
            try
            {
                return TryDownloadFile(url);
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
        private byte[] TryDownloadFile(string url)
        {
            var webClient = new WebClient();
            var result = webClient.DownloadData(url);

            webClient.Dispose();
            return result;
        }
    }
}
