using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using CoreRepo.Data.Account;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Services.Functions
{
    public static class CryptoFunctions
    {
        public static User CreateCryptoForPassword(User user)
        {
            var salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            user.Salt = salt;
            user.Password = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: user.Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return user;
        }
    }
}
