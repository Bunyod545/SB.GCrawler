using System.Linq;
using Microsoft.AspNetCore.Http;
using SB.Auto.DependenyInjection;
using SB.GCrawler.Api.Contexts.Tables;

namespace SB.GCrawler.Api.Services.CurrentUser
{
    /// <summary>
    /// 
    /// </summary>
    [ScopedService]
    public class CurrentUserService : ICurrentUserService
    {
        /// <summary>
        /// 
        /// </summary>
        private IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long? GetCurrentUserId()
        {
            var claims = _httpContextAccessor?.HttpContext?.User?.Claims;
            var claim = claims?.FirstOrDefault(f=>f.Type == nameof(GCrawlerUser.Id));
            if (claim == null)
                return 1;

            return long.Parse(claim.Value);
        }
    }
}