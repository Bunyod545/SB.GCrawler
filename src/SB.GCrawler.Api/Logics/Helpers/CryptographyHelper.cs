using SB.GCrawler.Api.Logics.Models;
using System;
using System.Security.Cryptography;

namespace SB.GCrawler.Api.Logics.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class CryptographyHelper
    {
        /// <summary>
        /// 
        /// </summary>
        private const int SaltSize = 32;

        /// <summary>
        /// 
        /// </summary>
        private const int HashSize = 64;

        /// <summary>
        /// 
        /// </summary>
        private const int Iterations = 1000;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static HashSalt GenerateSaltedHash(string password)
        {
            var saltBytes = new byte[SaltSize];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);

            var salt = Convert.ToBase64String(saltBytes);
            var passwordBytes = new Rfc2898DeriveBytes(password, saltBytes, Iterations);

            var hashPassword = Convert.ToBase64String(passwordBytes.GetBytes(HashSize));
            var hashSalt = new HashSalt { Hash = hashPassword, Salt = salt };

            return hashSalt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        /// <returns></returns>
        public static bool VerifyPassword(string password, string passwordHash, string passwordSalt)
        {
            var saltBytes = Convert.FromBase64String(passwordSalt);
            var passwordBytes = new Rfc2898DeriveBytes(password, saltBytes, Iterations);

            return Convert.ToBase64String(passwordBytes.GetBytes(HashSize)) == passwordHash;
        }
    }
}
