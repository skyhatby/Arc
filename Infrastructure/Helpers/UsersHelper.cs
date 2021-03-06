﻿using System.Globalization;
using System.Security.Cryptography;

namespace Infrastructure.Helpers
{
    public class UsersHelper
    {
        public static string GeneratePassword()
        {
            using (var prng = new RNGCryptoServiceProvider())
            {
                return GenerateToken(prng);
            }
        }

        public static string GenerateToken(RandomNumberGenerator generator)
        {
            var tokenBytes = new byte[16];
            generator.GetBytes(tokenBytes);
            return tokenBytes.GetHashCode().ToString(CultureInfo.InvariantCulture);
        }

        public static string GetHash(string value, string passwordSault)
        {
            return (value + passwordSault).GetHashCode().ToString(CultureInfo.InvariantCulture);
        }
    }
}