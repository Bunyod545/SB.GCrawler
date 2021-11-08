using SB.Auto.DependenyInjection;
using SB.GCrawler.Api.Contexts.MultiSchema.Helpers;
using SB.GCrawler.Api.Services.CurrentUser;

namespace SB.GCrawler.Api.Services
{
    /// <summary>
    /// 
    /// </summary>
    [ScopedService]
    public class CurrentSchemaService : ICurrentSchemaService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ICurrentUserService _currentUserService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentUserService"></param>
        public CurrentSchemaService(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetCurrentSchema()
        {
            return string.Format(MultiSchemaHelper.SchemaTemplate, _currentUserService.GetCurrentUserId());
        }
    }
}
