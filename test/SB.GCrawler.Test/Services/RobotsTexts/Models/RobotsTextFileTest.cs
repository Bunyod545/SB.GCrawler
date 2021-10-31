using Microsoft.VisualStudio.TestTools.UnitTesting;
using SB.GCrawler.Services.RobotsTexts;
using SB.GCrawler.Test.Services.RobotsTexts.Helpers;

namespace SB.GCrawler.Test.Services.RobotsTexts.Models
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class RobotsTextFileTest
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void IsDisallow_Success()
        {
            var helper = new RobotsTextsHelpers();
            var robotsFile = helper.Parse(RobotsTextsHelpersConsts.TestRobotsText);
            robotsFile.SetBaseUrl(RobotsTextsHelpersConsts.BaseUrl);

            var isAllow = robotsFile.IsAllow("gcrawler", "http://www.example.com/nogcrawlerbot/test");
            Assert.IsFalse(isAllow);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void IsAllow_Success()
        {
            var helper = new RobotsTextsHelpers();
            var robotsFile = helper.Parse(RobotsTextsHelpersConsts.AllowedUserAgentsText);
            robotsFile.SetBaseUrl(RobotsTextsHelpersConsts.BaseUrl);

            IsAllow(robotsFile, "full-allow", "/test");
            IsAllow(robotsFile, "equal-full-allow", "/test");
            
            IsAllow(robotsFile, "fish-allow", "/fish");
            IsAllow(robotsFile, "fish-allow", "/fish.html");
            IsAllow(robotsFile, "fish-allow", "/fish/salmon.html");
            IsAllow(robotsFile, "fish-allow", "/fishheads");
            IsAllow(robotsFile, "fish-allow", "/fishheads/yummy.html");
            IsAllow(robotsFile, "fish-allow", "/fish.php?id=anything");

            IsDisallow(robotsFile, "fish-allow", "/Fish.asp");
            IsDisallow(robotsFile, "fish-allow", "/catfish");
            IsDisallow(robotsFile, "fish-allow", "/?id=fish");
            IsDisallow(robotsFile, "fish-allow", "/desert/fish");
            

            IsAllow(robotsFile, "equal-fish-allow", "/fish");
            IsAllow(robotsFile, "equal-fish-allow", "/fish.html");
            IsAllow(robotsFile, "equal-fish-allow", "/fish/salmon.html");
            IsAllow(robotsFile, "equal-fish-allow", "/fishheads");
            IsAllow(robotsFile, "equal-fish-allow", "/fishheads/yummy.html");
            IsAllow(robotsFile, "equal-fish-allow", "/fish.php?id=anything");

            IsDisallow(robotsFile, "equal-fish-allow", "/Fish.asp");
            IsDisallow(robotsFile, "equal-fish-allow", "/catfish");
            IsDisallow(robotsFile, "equal-fish-allow", "/?id=fish");
            IsDisallow(robotsFile, "equal-fish-allow", "/desert/fish");


            IsAllow(robotsFile, "fish-folder-allow", "/fish/");
            IsAllow(robotsFile, "fish-folder-allow", "/animals/fish/");
            IsAllow(robotsFile, "fish-folder-allow", "/fish/?id=anything");
            IsAllow(robotsFile, "fish-folder-allow", "/fish/salmon.htm");
            
            IsDisallow(robotsFile, "fish-folder-allow", "/fish");
            IsDisallow(robotsFile, "fish-folder-allow", "/fish.html");
            IsDisallow(robotsFile, "fish-folder-allow", "/Fish/Salmon.asp");
            

            IsAllow(robotsFile, "php-path-allow", "/index.php");
            IsAllow(robotsFile, "php-path-allow", "/filename.php");
            IsAllow(robotsFile, "php-path-allow", "/folder/filename.php");
            IsAllow(robotsFile, "php-path-allow", "/folder/filename.php?id=test");
            IsAllow(robotsFile, "php-path-allow", "/folder/any.php.file.html");
            IsAllow(robotsFile, "php-path-allow", "/filename.php/");
           
            IsDisallow(robotsFile, "php-path-allow", "/windows.PHP");
           

            IsAllow(robotsFile, "php-end-allow", "/filename.php");
            IsAllow(robotsFile, "php-end-allow", "/folder/filename.php");

            IsDisallow(robotsFile, "php-end-allow", "/filename.php?id=test");
            IsDisallow(robotsFile, "php-end-allow", "/filename.php/");
            IsDisallow(robotsFile, "php-end-allow", "/filename.php5");
            IsDisallow(robotsFile, "php-end-allow", "/windows.PHP");


            IsAllow(robotsFile, "fish-php-allow", "/fish.php");
            IsAllow(robotsFile, "fish-php-allow", "/fishheads/catfish.php?id=test");
            
            IsDisallow(robotsFile, "fish-php-allow", "/Fish.PHP");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="robotsFile"></param>
        /// <param name="userAgent"></param>
        /// <param name="path"></param>
        private void IsAllow(RobotsTextFile robotsFile, string userAgent, string path)
        {
            var isAllow = robotsFile.IsAllow(userAgent, "http://www.example.com" + path);
            Assert.IsTrue(isAllow);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="robotsFile"></param>
        /// <param name="userAgent"></param>
        /// <param name="path"></param>
        private void IsDisallow(RobotsTextFile robotsFile, string userAgent, string path)
        {
            var isAllow = robotsFile.IsAllow(userAgent, "http://www.example.com" + path);
            Assert.IsFalse(isAllow);
        }
    }
}