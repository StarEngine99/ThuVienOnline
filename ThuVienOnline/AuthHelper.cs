using System;
using System.Globalization;
using System.Security.Cryptography;

namespace ThuVienOnline
{
    internal static class AuthHelper
    {
        private const int Iterations = 120000;

        internal static string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(salt);
            }

            byte[] hash;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                hash = deriveBytes.GetBytes(32);
            }

            return "PBKDF2-SHA256$" + Iterations.ToString(CultureInfo.InvariantCulture) + "$"
                + Convert.ToBase64String(salt) + "$" + Convert.ToBase64String(hash);
        }

        internal static bool VerifyPassword(string password, string storedHash)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(storedHash))
            {
                return false;
            }

            string[] parts = storedHash.Split('$');
            int iterations;
            byte[] salt;
            byte[] expectedHash;
            if (parts.Length != 4
                || parts[0] != "PBKDF2-SHA256"
                || !int.TryParse(parts[1], NumberStyles.None, CultureInfo.InvariantCulture, out iterations)
                || iterations < 1
                || iterations > 1000000)
            {
                return false;
            }

            try
            {
                salt = Convert.FromBase64String(parts[2]);
                expectedHash = Convert.FromBase64String(parts[3]);
            }
            catch (FormatException)
            {
                return false;
            }

            if (salt.Length != 16 || expectedHash.Length != 32)
            {
                return false;
            }

            byte[] actualHash;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                actualHash = deriveBytes.GetBytes(expectedHash.Length);
            }

            int difference = 0;
            for (int i = 0; i < expectedHash.Length; i++)
            {
                difference |= expectedHash[i] ^ actualHash[i];
            }

            return difference == 0;
        }
    }
}
