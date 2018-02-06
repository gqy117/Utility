﻿namespace Utility
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;

    public class PasswordWithSaltHasher
    {
        public HashWithSaltResult HashWithSalt(string password, int saltLength, HashAlgorithm hashAlgo)
        {
            RNG rng = new RNG();
            byte[] saltBytes = rng.GenerateRandomCryptographicBytes(saltLength);
            byte[] passwordAsBytes = Encoding.UTF8.GetBytes(password);
            List<byte> passwordWithSaltBytes = new List<byte>();

            passwordWithSaltBytes.AddRange(passwordAsBytes);
            // passwordWithSaltBytes.AddRange(saltBytes);

            byte[] digestBytes = hashAlgo.ComputeHash(passwordWithSaltBytes.ToArray());
            string hashValue = "";

            foreach (byte theByte in digestBytes)
            {
                hashValue += theByte.ToString("x2");
            }

            return new HashWithSaltResult(Convert.ToBase64String(saltBytes), Convert.ToBase64String(digestBytes));
        }
    }
}