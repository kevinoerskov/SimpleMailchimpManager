using System.Security.Cryptography;
using System.Text;

namespace SimpleMailchimpManager.Helper
{
    internal static class StringHelper
    {
        internal static string ToMd5Hash(this string source)
        {
            if (string.IsNullOrWhiteSpace(source)) return string.Empty;

            var bytes = Encoding.UTF8.GetBytes(source);
            var hashedBytes = MD5.Create().ComputeHash(bytes);
            var hashedSource = Encoding.UTF8.GetString(hashedBytes);

            return hashedSource;
        }
    }
}