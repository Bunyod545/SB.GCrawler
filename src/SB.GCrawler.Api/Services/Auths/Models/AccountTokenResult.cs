﻿namespace SB.GCrawler.Api.Services.Auths.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountTokenResult
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
        public AccountTokenResult(string token, string refreshToken, string fullName)
        {
            Token = token;
            RefeshToken = refreshToken;
            Fullname = fullName;
        }
    }
}