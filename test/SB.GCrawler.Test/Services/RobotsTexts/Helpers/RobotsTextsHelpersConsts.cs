namespace SB.GCrawler.Test.Services.RobotsTexts.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class RobotsTextsHelpersConsts
    {
        /// <summary>
        ///
        /// </summary>
        public const string TestRobotsText = 
        @"
            User-agent: gcrawler
            Disallow: /nogcrawlerbot/

            User-agent: *
            Allow: /

            Sitemap: http://www.example.com/sitemap.xml
        ";
        
        /// <summary>
        ///
        /// </summary>
        public const string EqualUserAgentsText = 
        @"
            User-agent: gcrawler
            Disallow: /nogcrawlerbot/

            User-agent: gcrawler
            Allow: /

            Sitemap: http://www.example.com/sitemap.xml
        ";
        
        /// <summary>
        ///
        /// </summary>
        public const string CombinedUserAgentsText = 
        @"
            User-agent: gcrawler
            Disallow: /nogcrawlerbot/

            User-agent: gcrawler_test
            User-agent: gcrawler_bot
            Allow: /home
            Allow: /settings
            Disallow: /account/

            Sitemap: http://www.example.com/sitemap.xml
        ";
    }
}