using SB.GCrawler.Api.Contexts.Tables;
using SB.GCrawler.Api.Services.UserTokens.Models;

namespace SB.GCrawler.Api.Services.UserTokens
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserTokenService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        TokenResult GenerateAndSaveUserToken(GCrawlerUser user);
    }
}
