using SB.Auto.DependenyInjection;
using SB.GCrawler.Api.Contexts;
using SB.GCrawler.Api.Contexts.Tables;
using SB.GCrawler.Api.Logics.Helpers;
using SB.GCrawler.Api.Logics.Models;
using SB.GCrawler.Api.Logics.Resources;
using SB.GCrawler.Api.Services.Auths.Models;
using System.Linq;
using System.Net;

namespace SB.GCrawler.Api.Services.Auths
{
    /// <summary>
    /// 
    /// </summary>
    [ScopedService]
    public class AuthService : IAuthService
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly GCrawlerContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public AuthService(GCrawlerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public ApiResponse<AuthResult> Login(LoginInfo info)
        {
            var user = _context.Users.FirstOrDefault(f => f.Login.ToLower() == info.Login.ToLower());
            if (user is null)
                return new ApiResponseError(HttpStatusCode.NotFound, UITexts.InvalidLogin);

            var verified = CryptographyHelper.VerifyPassword(info.Password, user.PasswordHash, user.PasswordSalt);
            if (!verified)
                return new ApiResponseError(HttpStatusCode.NotFound, UITexts.InvalidPassword);

            return GenerateAndSaveUserToken(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public ApiResponse<AuthResult> Register(RegisterInfo info)
        {
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

            return GenerateAndSaveUserToken(user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private AuthResult GenerateAndSaveUserToken(GCrawlerUser user)
        {
            var userToken = _context.UserTokens.FirstOrDefault(f => f.UserId == user.Id);
            if (userToken is null)
            {
                userToken = new GCrawlerUserToken();
                userToken.UserId = user.Id;
                _context.UserTokens.Add(userToken);
            }

            userToken.Token = JwtHelper.GetToken(user.Id.ToString());
            userToken.RefreshToken = JwtHelper.GetGuidToken();
            _context.SaveChanges();

            return new AuthResult(userToken.Token, userToken.RefreshToken, user.Fullname);
        }
    }
}
