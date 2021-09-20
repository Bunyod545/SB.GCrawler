using Microsoft.AspNetCore.Mvc;
using SB.GCrawler.Api.Services.Configs.Database;

namespace SB.GCrawler.Api.Controllers.Configs
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DatabaseConfigController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IDatabaseConfigService _databaseConfigService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseConfigService"></param>
        public DatabaseConfigController(IDatabaseConfigService databaseConfigService)
        {
            _databaseConfigService = databaseConfigService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        [HttpPost]
        public bool IsValidConnectionString(DatabaseConfigInfo config)
        {
            return _databaseConfigService.IsValidConnectionString(config);
        }
    }
}
