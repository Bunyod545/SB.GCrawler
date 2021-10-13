using SB.GCrawler.Api.Logics.Models;
using SB.GCrawler.Api.Services.Users.Models;
using SB.GCrawler.Api.Services.UserTokens.Models;

namespace SB.GCrawler.Api.Services.Users
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ApiResponse<bool> AnyUserExists();

        /// <summary>
        /// 
        /// </summary>
        ApiResponse<TokenResult> InitUser(InitUserInfo info);
    }
}
