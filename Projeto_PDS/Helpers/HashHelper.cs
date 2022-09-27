using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Projeto_PDS.Helpers
{
    internal class HashHelper
    {
        private const string SECRET_KEY = "iconictoptech";

        public static string Compute(string value)
        {
            var sha512 = SHA512Managed.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(value + SECRET_KEY);
            byte[] hash = sha512.ComputeHash(inputBytes);

            return Convert.ToBase64String(hash, Base64FormattingOptions.None);
        }

        public static bool Compare(string value, string hash)
        {
            return hash.Equals(Compute(value));
        }
    }
}
