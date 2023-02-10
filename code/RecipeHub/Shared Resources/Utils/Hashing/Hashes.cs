using System.Security.Cryptography;
using System.Text;

namespace Shared_Resources.Utils.Hashing
{
    /// <summary>
    /// Holds the hashing methods
    /// </summary>
    public static class Hashes
    {
        /// <summary>
        /// Hashes to sha512.
        /// </summary>
        /// <param name="passwordToHash">The password to hash.</param>
        /// <returns>The hashed string</returns>
        public static string HashToSha512(string passwordToHash)
        {
            using HashAlgorithm algorithm = SHA512.Create();
            var bytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(passwordToHash));
            var builder = new StringBuilder();
            foreach (var passwordByte in bytes)
            {
                builder.Append(passwordByte.ToString("x2"));
            }

            var hashedPassword = builder.ToString();
            return hashedPassword;
        }
    }
}
