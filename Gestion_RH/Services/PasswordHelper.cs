using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_RH.Services
{
    public static class PasswordHelper
    {
        public static string Hasher(string motDePasse)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16); // sel de 16 octets
            var pbkdf2 = new Rfc2898DeriveBytes(motDePasse, salt, 1000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32); // Hash sur 256 bits
            byte[] hashBytes = new byte[48];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 32);
            return Convert.ToBase64String(hashBytes);
        }

        public static bool Verifier(string motDePasse, string hashBase64)
        {
            byte[] hashBytes = Convert.FromBase64String(hashBase64);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(motDePasse, salt, 1000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);
            for (int i = 0; i < 32; i++)
            {
                if (hashBytes[i + 16] != hash[i]) return false;
            }
            return true;
        }
    }

}

