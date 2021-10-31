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
        public const string BaseUrl = "http://www.example.com/";

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

        /// <summary>
        ///
        /// </summary>
        public const string AllowedUserAgentsText = 
        @"
            User-agent: full-allow
            Allow: /
            
            User-agent: equal-full-allow
            Allow: /*
            
            User-agent: fish-allow
            Allow: /fish
            
            User-agent: equal-fish-allow
            Allow: /fish*
            
            User-agent: fish-folder-allow
            Allow: /fish/
            
            User-agent: php-path-allow
            Allow: /*.php
            
            User-agent: php-end-allow
            Allow: /*.php$
            
            User-agent: fish-php-allow
            Allow: /fish*.php
        ";
    }
}