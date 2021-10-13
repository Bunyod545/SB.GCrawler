using Microsoft.AspNetCore.Mvc;
using SB.GCrawler.Api.Logics.Models;
using SB.GCrawler.Api.Services.Users;
using SB.GCrawler.Api.Services.Users.Models;
using SB.GCrawler.Api.Services.UserTokens.Models;

namespace SB.GCrawler.Api.Controllers.Users
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ApiResponse<bool> AnyUserExists()=>_userService.AnyUserExists();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResponse<TokenResult> InitUser(InitUserInfo info) => _userService.InitUser(info);
    }
}
