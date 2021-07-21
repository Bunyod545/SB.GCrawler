using SB.GCrawler.Services.FileDownloaders;
using System.Reflection;

namespace SB.GCrawler.Test.Services.SiteMapDownloaders
{
    /// <summary>
    /// 
    /// </summary>
    public class TestFileDownloader : IFileDownloader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public byte[] DownloadFile(string url)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resFilestream = assembly.GetManifestResourceStream(url);

            if (resFilestream == null)
                return null;

            var result = new byte[resFilestream.Length];
            resFilestream.Read(result, 0, result.Length);

            resFilestream.Dispose();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public FileDownloadInfo GetFileInfo(string url)
        {
            throw new System.NotImplementedException();
        }
    }
}