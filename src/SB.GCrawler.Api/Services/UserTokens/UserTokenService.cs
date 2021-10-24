using SB.Auto.DependenyInjection;
using SB.GCrawler.Api.Contexts;
using SB.GCrawler.Api.Contexts.Tables;
using SB.GCrawler.Api.Logics.Helpers;
using SB.GCrawler.Api.Services.UserTokens.Models;
using System.Linq;

namespace SB.GCrawler.Api.Services.UserTokens
{
    /// <summary>
    /// 
    /// </summary>
    [ScopedService]
    public class UserTokenService : IUserTokenService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly CommonDbContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UserTokenService(CommonDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public TokenResult GenerateAndSaveUserToken(GCrawlerUser user)
        {
            var userToken = _context.UserTokens.FirstOrDefault(f => f.UserId == user.Id);
            if (userToken is null)
            {
                userToken = new GCrawlerUserToken();
                userToken.UserId = user.Id;
                _context.UserTokens.Add(userToken);
            }

            userToken.Token = JwtHelper.GetToken(user.Id.ToString());
            userToken.RefreshToken = JwtHelper.GetGuidToken();
            _context.SaveChanges();

            return new TokenResult(userToken.Token, userToken.RefreshToken, user.Fullname);
        }
    }
}
