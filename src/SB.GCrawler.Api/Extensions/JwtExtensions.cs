using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System;
using SB.GCrawler.Api.Logics.Helpers;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SB.GCrawler.Api.Logics
{
    /// <summary>
    /// 
    /// </summary>
    public static class JwtExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddJwt(this IServiceCollection services)
        {
            var keyByteArray = Encoding.ASCII.GetBytes(JwtHelper.SecretKey);
            var signingKey = new SymmetricSecurityKey(keyByteArray);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                ValidateIssuer = true,
                ValidIssuer = JwtHelper.ParamIss,

                ValidateAudience = true,
                ValidAudience = JwtHelper.ParamAud,

                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o => { o.TokenValidationParameters = tokenValidationParameters; });
        }
    }
}
