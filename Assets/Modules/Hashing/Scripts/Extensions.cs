using System;
using System.Text;

namespace Modules.Hashing
{
    public static class HashProviderExtensions
    {
        public static string Compute(this IHashProvider provider, string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(provider.Compute(bytes));
        }

        public static bool Verify(this IHashProvider provider, string input, string expectedHash)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            var expectedBytes = Convert.FromBase64String(expectedHash);
            return provider.Verify(bytes, expectedBytes);
        }
    }    
}