using Microsoft.AspNetCore.Mvc;
using SB.GCrawler.Api.Logics.Models;
using SB.GCrawler.Api.Services.Auths;
using SB.GCrawler.Api.Services.Auths.Models;

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
        /// <param name="authService"></param>
        public AccountController(IAccountService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResponse<AccountTokenResult> Login(LoginInfo info)
        {
            return _authService.Login(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResponse<AccountTokenResult> CreateAccount(RegisterInfo info)
        {
            return _authService.CreateAccount(info);
        }

    }
}
