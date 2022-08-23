using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace ECommerce.API.Helper
{
    public class HashPassword
    {
        public string hashpassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); 
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
