using SB.Auto.DependenyInjection;
using SB.GCrawler.Api.Contexts;
using SB.GCrawler.Api.Contexts.Tables;
using SB.GCrawler.Api.Logics.Helpers;
using SB.GCrawler.Api.Logics.Models;
using SB.GCrawler.Api.Logics.Resources;
using SB.GCrawler.Api.Services.Users.Models;
using SB.GCrawler.Api.Services.UserTokens;
using SB.GCrawler.Api.Services.UserTokens.Models;
using System.Linq;
using System.Net;

namespace SB.GCrawler.Api.Services.Users
{
    /// <summary>
    /// 
    /// </summary>
    [ScopedService]
    public class GCrawlerUserService : IGCrawlerUserService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly GCrawlerContext _context;

        /// <summary>
        /// 
        /// </summary>
        private readonly IUserTokenService _tokenService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public GCrawlerUserService(GCrawlerContext context, IUserTokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ApiResponse<bool> AnyUserExists()
        {
            return _context.Users.Count() > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public ApiResponse<TokenResult> InitUser(InitUserInfo info)
        {
            var validation = ValidateModel(info);
            if (!validation.IsSuccess)
                return validation.Error;

            var user = _context.Users.FirstOrDefault(f => f.Login.ToLower() == info.Login.ToLower());
            if (user is not null)
                return new ApiResponseError(HttpStatusCode.BadRequest, UITexts.LoginAlreadyExists);

            var hashSalt = CryptographyHelper.GenerateSaltedHash(info.Password);

            user = new GCrawlerUser();
            user.Login = info.Login;
            user.Fullname = info.FullName;
            user.PasswordHash = hashSalt.Hash;
            user.PasswordSalt = hashSalt.Salt;
            _context.Users.Add(user);
            _context.SaveChanges();

            return _tokenService.GenerateAndSaveUserToken(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private ApiResponse<TokenResult> ValidateModel(InitUserInfo info)
        {
            if (string.IsNullOrEmpty(info?.FullName))
                return new ApiResponseError(HttpStatusCode.BadRequest, UITexts.FullNameIsEmpty);

            if (string.IsNullOrEmpty(info?.Login))
                return new ApiResponseError(HttpStatusCode.BadRequest, UITexts.LoginIsEmpty);

            if (string.IsNullOrEmpty(info?.Password))
                return new ApiResponseError(HttpStatusCode.BadRequest, UITexts.PasswordIsEmpty);

            return new ApiResponse<TokenResult>();
        }
    }
}