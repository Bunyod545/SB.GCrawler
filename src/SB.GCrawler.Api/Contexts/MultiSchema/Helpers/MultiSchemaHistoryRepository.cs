using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Migrations.Internal;

namespace SB.GCrawler.Api.Contexts.MultiSchema
{
    /// <summary>
    /// 
    /// </summary>
    public class MultiSchemaHistoryRepository : NpgsqlHistoryRepository
    {
        /// <summary>
        /// 
        /// </summary>
        private string _tableSchema;

        /// <summary>
        /// 
        /// </summary>
        protected override string TableSchema => _tableSchema;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dependencies"></param>
        /// <returns></returns>
        public MultiSchemaHistoryRepository([NotNullAttribute] HistoryRepositoryDependencies dependencies, ICurrentDbContext currentContext) : base(dependencies)
        {
            var multiSchemaDbContext = currentContext.Context as IMultiSchemaDbContext;
            _tableSchema = multiSchemaDbContext?.TableSchema;
        }
    }
}