using Microsoft.AspNetCore.Mvc;
using SB.GCrawler.Api.Logics.Models;
using SB.GCrawler.Api.Services.Sites;

namespace SB.GCrawler.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SitesController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ISitesService _sitesService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sitesService"></param>
        public SitesController(ISitesService sitesService)
        {
            _sitesService = sitesService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResponse<SiteCreateResult> Create(SiteCreateArgs args) => _sitesService.Create(args);
    }
}



