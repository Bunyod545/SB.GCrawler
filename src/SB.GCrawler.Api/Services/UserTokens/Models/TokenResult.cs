namespace SB.GCrawler.Api.Services.UserTokens.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TokenResult
    {
        /// <summary>
        /// 
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RefeshToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Fullname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="refreshToken"></param>
        /// <param name="fullName"></param>
        public TokenResult(string token, string refreshToken, string fullName)
        {
            Token = token;
            RefeshToken = refreshToken;
            Fullname = fullName;
        }
    }
}
