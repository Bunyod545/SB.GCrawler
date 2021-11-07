using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using Npgsql.EntityFrameworkCore.PostgreSQL.Migrations;

namespace SB.GCrawler.Api.Contexts.MultiSchema
{
    /// <summary>
    /// 
    /// </summary>
    public class MultiSchemaMigrationsSqlGenerator : NpgsqlMigrationsSqlGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string TableSchema { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dependencies"></param>
        /// <param name="npgsqlOptions"></param>
        /// <returns></returns>
        public MultiSchemaMigrationsSqlGenerator([NotNullAttribute] MigrationsSqlGeneratorDependencies dependencies, [NotNullAttribute] INpgsqlOptions npgsqlOptions, ICurrentDbContext currentContext) : base(dependencies, npgsqlOptions)
        {
            var multiSchemaDbContext = currentContext.Context as IMultiSchemaDbContext;
            TableSchema = multiSchemaDbContext?.TableSchema;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="model"></param>
        /// <param name="builder"></param>
        protected override void Generate(MigrationOperation operation, IModel model, MigrationCommandListBuilder builder)
        {
            var schemaProperty = operation.GetType().GetProperty("Schema");
            if (schemaProperty != null)
                schemaProperty.SetValue(operation, TableSchema);

            if (operation is AddForeignKeyOperation addForeignKeyOperation) 
                addForeignKeyOperation.PrincipalSchema = addForeignKeyOperation.PrincipalSchema ?? TableSchema;

            base.Generate(operation, model, builder);
        }
    }
}