using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using SB.GCrawler.Api.Contexts.Tables;
using System.Text;

namespace SB.GCrawler.Api.Logics.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class JwtHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public const int ExpireMinute = 60;

        /// <summary>
        /// 
        /// </summary>
        public const int ExpireMinuteRefresh = 60;

        /// <summary>
        /// 
        /// </summary>
        public const string ParamIss = "HostAuth";

        /// <summary>
        /// 
        /// </summary>
        public const string ParamAud = "GCrawler";

        /// <summary>
        /// 
        /// </summary>
        public const string SecretKey = "Y2F0Y2hlciUyMHdvdbmclMjBsb3==0ZlJT+IwLm5ldA=+";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetToken(string userId)
        {
            var claims = new List<Claim>
            {
                new Claim(nameof(GCrawlerUser.Id), userId)
            };

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                ParamIss,
                ParamAud,
                notBefore: now,
                claims: claims,
                expires: now.Add(TimeSpan.FromMinutes(ExpireMinute)),
                signingCredentials: new SigningCredentials(
                    GetSecurityKey(),
                    SecurityAlgorithms.HmacSha256Signature
                )
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static SymmetricSecurityKey GetSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetGuidToken()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
