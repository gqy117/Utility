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
            byte[] passwordAsBytes = Encoding.UTF8.GetBytes(password);
            List<byte> passwordWithSaltBytes = new List<byte>();

            passwordWithSaltBytes.AddRange(passwordAsBytes);
            passwordWithSaltBytes.AddRange(saltBytes);

            byte[] digestBytes = hashAlgo.ComputeHash(passwordWithSaltBytes.ToArray());

            return new HashWithSaltResult(Convert.ToBase64String(saltBytes), Convert.ToBase64String(digestBytes));
        }
    }
}
