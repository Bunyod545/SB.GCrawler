using SB.GCrawler.Api.Logics.Models;
using SB.GCrawler.Api.Services.Auths.Models;

namespace SB.GCrawler.Api.Services.Auths
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        ApiResponse<AccountTokenResult> Login(LoginInfo info);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        ApiResponse<AccountTokenResult> CreateAccount(RegisterInfo info);
    }
}
