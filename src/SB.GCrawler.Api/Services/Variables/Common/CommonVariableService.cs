using System.Linq;
using SB.Auto.DependenyInjection;
using SB.Common.Logics.Variables;
using SB.Common.Logics.Variables.Interfaces;
using SB.GCrawler.Api.Contexts;
using SB.GCrawler.Api.Contexts.Tables;

namespace SB.GCrawler.Api.Services.Variables
{
    /// <summary>
    /// 
    /// </summary>
    [ScopedService]
    public partial class CommonVariableService : BaseVariableContext, ICommonVariableService, IVariableService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly CommonDbContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public CommonVariableService(CommonDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        public object GetVariableValue(Variable variable)
        {
            var dbVariable = _context.Variables.FirstOrDefault(f => f.Name == variable.Name);
            return dbVariable?.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        public void SetVariableValue(Variable variable, object value)
        {
            var dbVariable = _context.Variables.FirstOrDefault(f => f.Name == variable.Name);
            if (dbVariable == null)
            {
                dbVariable = new GCrawlerVariable();
                dbVariable.Name = variable.Name;
                _context.Variables.Add(dbVariable);
            }

            dbVariable.Value = value?.ToString();
            _context.SaveChanges();
        }
    }
}