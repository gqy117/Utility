namespace Utility
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;

    public class PasswordWithSaltHasher
    {
        private const int SaltLength = 64;
        private const int Iterations = 10000;
        private const int KeyLength = 256 / 8;

        public HashWithSaltResult HashWithSalt(string password)
        {
            RNG rng = new RNG();
            HashAlgorithm hashAlgo = SHA256.Create();

            byte[] saltBytes = rng.GenerateRandomCryptographicBytes(SaltLength);

            return HashWithSalt(password, saltBytes, hashAlgo);
        }

        public HashWithSaltResult HashWithSalt(string password, byte[] saltBytes, HashAlgorithm hashAlgo)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations))
            {
                return new HashWithSaltResult(Convert.ToBase64String(saltBytes), Convert.ToBase64String(pbkdf2.GetBytes(KeyLength)));
            }
        }
    }
}
