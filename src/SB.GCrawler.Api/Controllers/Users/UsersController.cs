using Microsoft.AspNetCore.Mvc;
using SB.GCrawler.Api.Services.Users;

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
        private readonly IGCrawlerUserService _userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        public UsersController(IGCrawlerUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public bool AnyUserExists()
        {
            return _userService.AnyUserExists();
        }
    }
}
