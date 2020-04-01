using System;
using System.Linq;

namespace NameValuePairs.Utils
{
    /// <summary>
    /// Utility class for generating random values
    /// </summary>
    public class RandomGenerator
    {
        public static Random Random { get; } = new Random();

        /// <summary>
        /// Random alphanumeric string
        /// </summary>
        public static string RandomString(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Random string
        /// </summary>
        public static string RandomStringExtended(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-!$%&/()=?*+~#}][{@";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}
