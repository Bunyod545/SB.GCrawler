using Microsoft.Extensions.DependencyInjection;
using SB.GCrawler.Api.Contexts;

namespace SB.GCrawler.Api
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceScopeFactoryExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceScopeFactory"></param>
        /// <param name="siteId"></param>
        /// <returns></returns>
        public static MultiSchemaDbContext CreateContext(this IServiceScopeFactory serviceScopeFactory, long siteId)
        {
            var scope = serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<MultiSchemaDbContext>();

            context.SetSiteSchema(siteId);
            return context;
        }
    }
}
