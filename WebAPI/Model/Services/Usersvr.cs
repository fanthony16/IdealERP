using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Model.DTO;
using static WebAPI.Model.DTO.User;


namespace WebAPI.Model.Services
{
    public class Usersvr : IUser
    {
        private readonly IdealERPContext dbContext;
        private readonly IPasswordHasher pwdHelper;
        public Usersvr(IdealERPContext dbContext, IPasswordHasher pwdHelper)
        {
            this.dbContext = dbContext;
            this.pwdHelper = pwdHelper;
        }
        public Task<User.UserList> CreateUserAsync(User.RegisterUser dto)
        {
            throw new NotImplementedException();
        }

        public UserList MapToUser(TblUser dbUser)
        {
            return new UserList
            {
                Email = dbUser.Email,
                FirstName = dbUser.FirstName,
                LastName = dbUser.LastName,
                PhoneNumber = dbUser.PhoneNumber,
                Status = dbUser.Status == 1 ? "Active" : dbUser.Status == 2 ? "Suspended" : "Pending",
                UserID = dbUser.Id
            };
        }

        public Task<User.UserList> GetAllUserByIdAsync(Guid id)
        {
            
            throw new NotImplementedException();
        }

        public async Task<List<User.UserList>> GetAllUsersAsync()
        {

            var users =  await dbContext.TblUsers.ToListAsync();
            return users.Select(MapToUser).ToList();

        }

        public async Task<bool> UpdateUser(Guid id, User.UpdateUser dto)
        {
            var user = await dbContext.TblUsers.FindAsync(id);

            if (user == null) return false;
            if (dto.FirstName != null) user.FirstName = dto.FirstName;
            if (dto.LastName != null) user.LastName = dto.LastName;
            if (dto.PhoneNumber != null) user.PhoneNumber = dto.PhoneNumber;
            if (dto.Email != null) user.Email = dto.Email;
            if (dto.Status != null) user.Status = dto.Status == "Active" ? 1: dto.Status == "Suspended" ? 2: 3;

            await dbContext.SaveChangesAsync();

            return true;

        }

        public async Task<bool> RegisterUserAsyn(RegisterUser dto)
        {
            
            TblUser nUser = new() { 
            FirstName = dto.FirstName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            LastName = dto.LastName,
            PasswordHash = pwdHelper.HashPassword(dto.Password)
            
        };
            
            await dbContext.TblUsers.AddAsync(nUser);
            await dbContext.SaveChangesAsync();

            return true;
            
        }

        public async Task<bool> ValidateUserAsyn(ValidateUser dto)
        {
            var _user = await dbContext.TblUsers.Where(x => x.Email == dto.Email).FirstOrDefaultAsync();

            if (_user != null)
            {

                if (pwdHelper.VerifyPassword(_user.PasswordHash, dto.Password))
                {
                    return true;
                }

            }
            return false;
            
        }
    }
}

