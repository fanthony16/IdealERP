using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Model.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            // Create a new instance of SHA256 hashing algorithm.
            using var sha256 = SHA256.Create();
            // Convert the input password string into a byte array using UTF-8 encoding.
            var bytes = Encoding.UTF8.GetBytes(password);
            // Compute the SHA-256 hash of the password bytes.
            var hash = sha256.ComputeHash(bytes);
            // Convert the hashed byte array into a Base64-encoded string to store or compare easily.
            return Convert.ToBase64String(hash);
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            // Hash the provided plain password and compare it with the stored hash.
            // Returns true if both hashes match, indicating the password is correct.
            return hashedPassword == HashPassword(providedPassword);

        }
    }
}
