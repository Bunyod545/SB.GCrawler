using SB.Common.Logics.Variables;

namespace SB.GCrawler.Api.Services.Variables
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICommonVariableService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        Variable<string> SitesFilesPath { get; set; }
    }
}