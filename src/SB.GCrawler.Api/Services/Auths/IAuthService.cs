using SB.GCrawler.Api.Logics.Models;
using SB.GCrawler.Api.Services.Auths.Models;

namespace SB.GCrawler.Api.Services.Auths
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        ApiResponse<AuthResult> Login(LoginInfo info);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        ApiResponse<AuthResult> Register(RegisterInfo info);
    }
}
