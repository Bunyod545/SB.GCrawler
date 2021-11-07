using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SB.GCrawler.Api.Contexts
{
    /// <summary>
    /// 
    /// </summary>
    public static class MultiSchemaDbContextExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="modelBuilder"></param>
        public static void SetTablesSchema(this MultiSchemaDbContext context, ModelBuilder modelBuilder)
        {
            var entities = modelBuilder.Model.GetEntityTypes().ToList();
            entities.ForEach(f => f.SetIsTableExcludedFromMigrations(true));

            var tablesTypes = context.GetMultiSchemaContextTables();
            tablesTypes.ForEach(f => SetTableSchema(f, context, modelBuilder));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="modelBuilder"></param>
        private static void SetTableSchema(Type table, MultiSchemaDbContext context, ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity(table);
            entity?.Metadata.SetIsTableExcludedFromMigrations(false);
            entity?.Metadata.SetSchema(context.TableSchema);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<Type> GetMultiSchemaContextTables(this MultiSchemaDbContext context)
        {
            var properties = context
                .GetType()
                .GetProperties()
                .Where(w =>w.PropertyType.IsGenericType && w.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

            return properties.Select(s => s.PropertyType.GetGenericArguments().FirstOrDefault()).ToList();
        }
    }
}