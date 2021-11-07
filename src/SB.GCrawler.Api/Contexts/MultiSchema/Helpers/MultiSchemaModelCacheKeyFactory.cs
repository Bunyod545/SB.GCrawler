using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SB.GCrawler.Api.Contexts.MultiSchema
{
    /// <summary>
    /// 
    /// </summary>
    public class MultiSchemaModelCacheKeyFactory : IModelCacheKeyFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public object Create(DbContext context)
        {
            return context is MultiSchemaDbContext myContext ?
                (context.GetType(), myContext.TableSchema) :
                (object)context.GetType();
        }
    }
}