using System.Globalization;
using System.Security.Cryptography;

namespace Entities
{
    public class UsersHelper
    {
        internal static string GeneratePassword()
        {
            using (var prng = new RNGCryptoServiceProvider())
            {
                return GenerateToken(prng);
            }
        }

        internal static string GenerateToken(RandomNumberGenerator generator)
        {
            var tokenBytes = new byte[16];
            generator.GetBytes(tokenBytes);
            return tokenBytes.GetHashCode().ToString(CultureInfo.InvariantCulture);
        }
    }
}