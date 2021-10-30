using Microsoft.VisualStudio.TestTools.UnitTesting;
using SB.GCrawler.Services.RobotsTexts;

namespace SB.GCrawler.Test.Services.RobotsTexts.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class RobotsTextsLineHelperTest
    {
        /// <summary>
        /// 
        /// </summary>
        private RobotsTextsLineHelper _lineHelper;

        /// <summary>
        /// 
        /// </summary>
        public RobotsTextsLineHelperTest()
        {
            _lineHelper = new RobotsTextsLineHelper();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void IsCommentLine_Success()
        {
            const string commentLine = "# Example 1: Block only gcrawler";
            var isCommentLine = _lineHelper.IsCommentLine(commentLine);

            Assert.IsTrue(isCommentLine);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void IsCommentLine_Error()
        {
            const string commentLine = "Example 1: Block only gcrawler";
            var isCommentLine = _lineHelper.IsCommentLine(commentLine);

            Assert.IsFalse(isCommentLine);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void IsLineUserAgent_Success()
        {
            string line = "User-agent: gcrawler";
            var isLineStartsWith = _lineHelper.IsLineStartsWith(line, RobotsTextConsts.UserAgentKey);
            Assert.IsTrue(isLineStartsWith);
            
            line = "user-agent: gcrawler";
            isLineStartsWith = _lineHelper.IsLineStartsWith(line, RobotsTextConsts.UserAgentKey);
            Assert.IsTrue(isLineStartsWith);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ParseLineUserAgent_Success()
        {
            string line = "User-agent: gcrawler #test comment";
            var textLine = _lineHelper.ParseLine(line) as RobotsTextUserAgentLine;

            Assert.IsNotNull(textLine);
            Assert.AreEqual("gcrawler", textLine.Name);
            Assert.AreEqual("test comment", textLine.Comment);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void IsLineAllow_Success()
        {
            string line = "Allow: /";
            var isLineStartsWith = _lineHelper.IsLineStartsWith(line, RobotsTextConsts.AllowKey);
            Assert.IsTrue(isLineStartsWith);
            
            line = "allow: /";
            isLineStartsWith = _lineHelper.IsLineStartsWith(line, RobotsTextConsts.AllowKey);
            Assert.IsTrue(isLineStartsWith);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ParseLineAllow_Success()
        {
            string line = "Allow: / #test comment";
            var textLine = _lineHelper.ParseLine(line) as RobotsTextAllowLine;

            Assert.IsNotNull(textLine);
            Assert.AreEqual("/", textLine.Url);
            Assert.AreEqual("test comment", textLine.Comment);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void IsLineDissallow_Success()
        {
            string line = "Disallow: /";
            var isLineStartsWith = _lineHelper.IsLineStartsWith(line, RobotsTextConsts.DisallowKey);
            Assert.IsTrue(isLineStartsWith);
            
            line = "disallow: /";
            isLineStartsWith = _lineHelper.IsLineStartsWith(line, RobotsTextConsts.DisallowKey);
            Assert.IsTrue(isLineStartsWith);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ParseLineDisallow_Success()
        {
            string line = "Disallow: / #test comment";
            var textLine = _lineHelper.ParseLine(line) as RobotsTextDisallowLine;

            Assert.IsNotNull(textLine);
            Assert.AreEqual("/", textLine.Url);
            Assert.AreEqual("test comment", textLine.Comment);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void IsLineSiteMap_Success()
        {
            string line = "Sitemap: /";
            var isLineStartsWith = _lineHelper.IsLineStartsWith(line, RobotsTextConsts.SiteMapKey);
            Assert.IsTrue(isLineStartsWith);
            
            line = "sitemap: /";
            isLineStartsWith = _lineHelper.IsLineStartsWith(line, RobotsTextConsts.SiteMapKey);
            Assert.IsTrue(isLineStartsWith);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ParseLineSiteMap_Success()
        {
            string line = "Sitemap: http://www.example.com/sitemap.xml #test comment";
            var textLine = _lineHelper.ParseLine(line) as RobotsTextSiteMapLine;

            Assert.IsNotNull(textLine);
            Assert.AreEqual("http://www.example.com/sitemap.xml", textLine.Url);
            Assert.AreEqual("test comment", textLine.Comment);
        }
    }
}