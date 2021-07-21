namespace SB.GCrawler.Services.FileDownloaders
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFileDownloader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        FileDownloadInfo GetFileInfo(string url);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        byte[] DownloadFile(string url);
    }
}
