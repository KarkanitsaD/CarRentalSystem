using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Business.Helpers
{
    public class PasswordHasher
    {
        private readonly IConfiguration _configuration;

        public PasswordHasher(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GeneratePasswordHash(string password)
        {
            byte[] passwordBytes = Encoding.Default.GetBytes(password);
            var hashBytes = new SHA256Managed().ComputeHash(passwordBytes);
            var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            var salt = _configuration.GetSection("Salt").Value;
            var result = new StringBuilder(hash);
            result.Append(salt);
            return result.ToString();
        }
    }
}