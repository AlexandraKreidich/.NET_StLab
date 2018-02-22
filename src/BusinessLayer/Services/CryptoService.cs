using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLayer.Services
{
    internal struct PasswordObject
    {
        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }
    }

    internal static class CryptoService
    {
        private static byte[] Combine(byte[] a, byte[] b)
        {
            byte[] c = new byte[a.Length + b.Length];
            System.Buffer.BlockCopy(a, 0, c, 0, a.Length);
            System.Buffer.BlockCopy(b, 0, c, a.Length, b.Length);
            return c;
        }

        private static byte[] GetSalt()
        {
            byte[] salt = new byte[50];

            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(salt);
            }

            return salt;
        }

        public static PasswordObject GetHash(string str, byte[] salt = null)
        {
            if (salt == null)
            {
                salt = GetSalt();
            }

            byte[] data = Encoding.UTF8.GetBytes(str);

            byte[] saltedPass = Combine(data, salt);

            byte[] hashedInputBytes;

            using (SHA512 shaM = new SHA512Managed())
            {
                hashedInputBytes = shaM.ComputeHash(saltedPass);
            }

            return new PasswordObject()
            {
                PasswordHash = hashedInputBytes,
                Salt = salt
            };
        }

    }
}
