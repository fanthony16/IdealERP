using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model.Services
{
    public interface IPasswordHasher
    {
        public string HashPassword(string password);
        public bool VerifyPassword(string hashedPassword, string providedPassword);
        
    }
}
