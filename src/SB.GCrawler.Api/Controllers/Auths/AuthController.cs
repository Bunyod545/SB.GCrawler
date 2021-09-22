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
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IAuthService _authService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authService"></param>
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResponse<AuthResult> Login(LoginInfo info)
        {
            return _authService.Login(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResponse<AuthResult> Register(RegisterInfo info)
        {
            return _authService.Register(info);
        }

    }
}
