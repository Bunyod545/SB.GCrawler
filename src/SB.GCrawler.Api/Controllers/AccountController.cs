using Microsoft.AspNetCore.Mvc;
using SB.GCrawler.Api.Logics.Models;
using SB.GCrawler.Api.Services.Auths;
using SB.GCrawler.Api.Services.Auths.Models;
using SB.GCrawler.Api.Services.Users;
using SB.GCrawler.Api.Services.Users.Models;
using SB.GCrawler.Api.Services.UserTokens.Models;

namespace SB.GCrawler.Api.Controllers.Auths
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IAccountService _authService;
        
        /// <summary>
        /// 
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authService"></param>
        /// <param name="userService"></param>
        public AccountController(IAccountService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResponse<TokenResult> Login(LoginInfo info) => _authService.Login(info);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResponse<TokenResult> InitUser(InitUserInfo info) => _userService.InitUser(info);
    }
}
