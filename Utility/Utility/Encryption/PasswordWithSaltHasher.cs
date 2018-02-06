namespace Utility
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;

    public class PasswordWithSaltHasher
    {
        public HashWithSaltResult HashWithSalt(string password)
        {
            RNG rng = new RNG();
            int saltLength = 64;
            HashAlgorithm hashAlgo = SHA256.Create();
            
            byte[] saltBytes = rng.GenerateRandomCryptographicBytes(saltLength);

            return HashWithSalt(password, saltBytes, hashAlgo);
        }

        public HashWithSaltResult HashWithSalt(string password, byte[] saltBytes, HashAlgorithm hashAlgo)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 20);

            return new HashWithSaltResult(Convert.ToBase64String(saltBytes), Convert.ToBase64String(pbkdf2.GetBytes(20)));
        }
    }
}
