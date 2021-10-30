using Microsoft.VisualStudio.TestTools.UnitTesting;
using SB.GCrawler.Services.RobotsTexts;

namespace SB.GCrawler.Test.Services.RobotsTexts.Helpers
{
    /// <summary>
    ///
    /// </summary>
    [TestClass]
    public class RobotsTextsHelpersTest
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Parse_Success()
        {
            var helper = new RobotsTextsHelpers();
            var robotsFile = helper.Parse(RobotsTextsHelpersConsts.TestRobotsText);

            Assert.AreEqual(1, robotsFile.SiteMaps.Count);
            Assert.AreEqual(2, robotsFile.UserAgents.Count);
        }
        
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Parse_EqualUserAgents_Success()
        {
            var helper = new RobotsTextsHelpers();
            var robotsFile = helper.Parse(RobotsTextsHelpersConsts.EqualUserAgentsText);

            Assert.AreEqual(1, robotsFile.SiteMaps.Count);
            Assert.AreEqual(1, robotsFile.UserAgents.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Parse_CombinedUserAgents_Success()
        {
            var helper = new RobotsTextsHelpers();
            var robotsFile = helper.Parse(RobotsTextsHelpersConsts.CombinedUserAgentsText);

            Assert.AreEqual(1, robotsFile.SiteMaps.Count);
            Assert.AreEqual(3, robotsFile.UserAgents.Count);

            Assert.AreEqual(3, robotsFile.UserAgents[1].Rules.Count);
            Assert.AreEqual(3, robotsFile.UserAgents[2].Rules.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ParseLines_Success()
        {
            var helper = new RobotsTextsHelpers();
            var lines = helper.ParseLines(RobotsTextsHelpersConsts.TestRobotsText);

            Assert.AreEqual(typeof(RobotsTextEmptyLine), lines[0].GetType());
            Assert.AreEqual(typeof(RobotsTextUserAgentLine), lines[1].GetType());
            Assert.AreEqual(typeof(RobotsTextDisallowLine), lines[2].GetType());
            Assert.AreEqual(typeof(RobotsTextEmptyLine), lines[3].GetType());
            Assert.AreEqual(typeof(RobotsTextUserAgentLine), lines[4].GetType());
            Assert.AreEqual(typeof(RobotsTextAllowLine), lines[5].GetType());
            Assert.AreEqual(typeof(RobotsTextEmptyLine), lines[6].GetType());
            Assert.AreEqual(typeof(RobotsTextSiteMapLine), lines[7].GetType());
            Assert.AreEqual(typeof(RobotsTextEmptyLine), lines[8].GetType());
        }
    }
}