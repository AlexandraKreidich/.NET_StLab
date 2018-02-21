using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLayer.Services
{
    internal static class CryptoService
    {
        public static byte[] ConcatBytes(byte[] a, byte[] b)
        {
            byte[] c = new byte[a.Length + b.Length];
            System.Buffer.BlockCopy(a, 0, c, 0, a.Length);
            System.Buffer.BlockCopy(b, 0, c, a.Length, b.Length);
            return c;
        }
        public static string GeneratePasswordHash(string userPassword)
        {
            byte[] salt = new byte[50];

            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(salt);
            }

            var data = Encoding.UTF8.GetBytes(userPassword);

            var saltedPass = ConcatBytes(data, salt);

            byte[] hashedInputBytes;

            using (SHA512 shaM = new SHA512Managed())
            {
                hashedInputBytes = shaM.ComputeHash(saltedPass);
            }

            Console.WriteLine($"hashedInputBytes: {hashedInputBytes}");

            var hashedInputStringBuilder = new System.Text.StringBuilder(hashedInputBytes.Length * 2);

            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.AppendFormat("{0:x2}", b);

            return hashedInputStringBuilder.ToString();
        }
    }
}
