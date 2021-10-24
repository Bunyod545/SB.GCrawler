using SB.Auto.DependenyInjection;
using SB.GCrawler.Api.Contexts;
using SB.GCrawler.Api.Logics.Helpers;
using SB.GCrawler.Api.Logics.Models;
using SB.GCrawler.Api.Logics.Resources;
using SB.GCrawler.Api.Services.Auths.Models;
using SB.GCrawler.Api.Services.UserTokens;
using SB.GCrawler.Api.Services.UserTokens.Models;
using System.Linq;
using System.Net;

namespace SB.GCrawler.Api.Services.Auths
{
    /// <summary>
    /// 
    /// </summary>
    [ScopedService]
    public class AccountService : IAccountService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly CommonDbContext _context;

        /// <summary>
        /// 
        /// </summary>
        private readonly IUserTokenService _tokenService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public AccountService(CommonDbContext context, IUserTokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public ApiResponse<TokenResult> Login(LoginInfo info)
        {
            var user = _context.Users.FirstOrDefault(f => f.Login.ToLower() == info.Login.ToLower());
            if (user is null)
                return new ApiResponseError(HttpStatusCode.NotFound, UITexts.InvalidLogin);

            var verified = CryptographyHelper.VerifyPassword(info.Password, user.PasswordHash, user.PasswordSalt);
            if (!verified)
                return new ApiResponseError(HttpStatusCode.NotFound, UITexts.InvalidPassword);

            return _tokenService.GenerateAndSaveUserToken(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public ApiResponse<TokenResult> CreateAccount(RegisterInfo info)
        {
            var validation = ValidateModel(info);
            if (validation.IsSuccess == false)
                return validation.Error;
            
            var user = _context.Users.FirstOrDefault(f => f.Login.ToLower() == info.Login.ToLower());
            if (user is not null)
                return new ApiResponseError(HttpStatusCode.BadRequest, UITexts.LoginAlreadyExists);

            var hashSalt = CryptographyHelper.GenerateSaltedHash(info.Password);

            user = new GCrawlerUser();
            user.Login = info.Login;
            user.Fullname = info.Fullname;
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
        private ApiResponse<TokenResult> ValidateModel(RegisterInfo info)
        {
            if (string.IsNullOrEmpty(info?.Fullname))
                return new ApiResponseError(HttpStatusCode.BadRequest, UITexts.FullNameIsEmpty);

            if (string.IsNullOrEmpty(info?.Login))
                return new ApiResponseError(HttpStatusCode.BadRequest, UITexts.LoginIsEmpty);

            if (string.IsNullOrEmpty(info?.Password))
                return new ApiResponseError(HttpStatusCode.BadRequest, UITexts.PasswordIsEmpty);

            return new ApiResponse<TokenResult>();
        }
    }
}
