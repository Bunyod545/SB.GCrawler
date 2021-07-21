using Microsoft.VisualStudio.TestTools.UnitTesting;
using SB.GCrawler.Services.SiteMapDownloaders;

namespace SB.GCrawler.Test.Services.SiteMapDownloaders
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class SiteMapDownloaderTest
    {
        /// <summary>
        /// 
        /// </summary>
        public const string TestSiteMapFileCorrectUrl = "SB.GCrawler.Test.Services.SiteMapDownloaders.Helpers.TestSiteMap.xml";
                                                         
        /// <summary>
        /// 
        /// </summary>
        public const string TestSiteMapFileIncorrectUrl = "TestSiteMap.xml";

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void GetSiteMapInfo_Successfull_Test()
        {
            var siteMapDownloader = GetSiteMapDownloader();
            var siteMapInfo = siteMapDownloader.GetSiteMapInfo(TestSiteMapFileCorrectUrl);

            Assert.IsNotNull(siteMapInfo);
            Assert.IsNotNull(siteMapInfo.Items);
            Assert.AreEqual(siteMapInfo.Items.Count, 1);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void GetSiteMapInfo_Error_Test()
        {
            var siteMapDownloader = GetSiteMapDownloader();
            var siteMapInfo = siteMapDownloader.GetSiteMapInfo(TestSiteMapFileIncorrectUrl);

            Assert.IsNull(siteMapInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private SiteMapDownloader GetSiteMapDownloader()
        {
            return new SiteMapDownloader(new TestFileDownloader());
        }
    }
}
