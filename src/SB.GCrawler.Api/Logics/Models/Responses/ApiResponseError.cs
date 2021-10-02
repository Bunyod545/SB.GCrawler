using SB.GCrawler.Api.Logics.Helpers;
using System.Net;
using System.Net.Mail;

namespace SB.GCrawler.Api.Logics.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiResponseError
    {
        /// <summary>
        /// 
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ApiResponseError()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        public ApiResponseError(HttpStatusCode statusCode, string message)
        {
            ErrorCode = (int)statusCode;
            ErrorMessage = message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        public ApiResponseError(int errorCode, string message)
        {
            ErrorCode = errorCode;
            ErrorMessage = message;
        }
    }
}
