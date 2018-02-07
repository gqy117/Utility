namespace Utility
{
    using System;
    using System.Security.Cryptography;

    public sealed class PasswordHash
    {
        private const int SaltSize = 16, HashSize = 20, HashIter = 10000;
        private byte[] _salt, _hash;

        public byte[] Salt => (byte[])_salt.Clone();
        public byte[] HashedPassword => (byte[])_hash.Clone();

        public void Hash(string password)
        {
            new RNGCryptoServiceProvider().GetBytes(_salt = new byte[SaltSize]);
            _hash = new Rfc2898DeriveBytes(password, _salt, HashIter).GetBytes(HashSize);
        }

        public void Hash(byte[] hashBytes)
        {
            Array.Copy(hashBytes, 0, _salt = new byte[SaltSize], 0, SaltSize);
            Array.Copy(hashBytes, SaltSize, _hash = new byte[HashSize], 0, HashSize);
        }

        public void Hash(string salt, string hash) 
        {
            this.Hash(Convert.FromBase64String(salt), Convert.FromBase64String(hash));
        }

        public void Hash(byte[] salt, byte[] hash)
        {
            Array.Copy(salt, 0, _salt = new byte[SaltSize], 0, SaltSize);
            Array.Copy(hash, 0, _hash = new byte[HashSize], 0, HashSize);
        }

        public byte[] ToArray()
        {
            byte[] hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(_salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(_hash, 0, hashBytes, SaltSize, HashSize);

            return hashBytes;
        }

        public bool Verify(string salt, string hash, string password)
        {
            this.Hash(salt, hash);

            return Verify(password);
        }

        public bool Verify(string password)
        {
            byte[] test = new Rfc2898DeriveBytes(password, _salt, HashIter).GetBytes(HashSize);
            for (int i = 0; i < HashSize; i++)
                if (test[i] != _hash[i])
                    return false;
            return true;
        }
    }
}
