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

        public UserList MapToUser(VwUser dbUser)
        {
            return new UserList
            {
                Email = dbUser.Email,
                FirstName = dbUser.FirstName,
                LastName = dbUser.LastName,
                PhoneNumber = dbUser.PhoneNumber,
                Status = dbUser.Status == 1 ? "Active" : dbUser.Status == 2 ? "Suspended" : "Pending",
                UserID = dbUser.Id,
                OrganisationID = dbUser.OrganizationId
            };
        }

        public Task<User.UserList> GetAllUserByIdAsync(Guid id)
        {
            
            throw new NotImplementedException();
        }

        public async Task<List<User.UserList>> GetAllUsersAsync(char userCategory)
        {
            
            if (userCategory.Equals("U"))
            {

                var users = dbContext.VwUsers.Where(a => !dbContext.TblUserOrganizations.Any(b => b.UserId == a.Id));

                if (users is not null)
                {
                    return users.Select(MapToUser).ToList();
                }

                return null;
            }
            else
            {

                var users = await dbContext.VwUsers.ToListAsync();
                if (users is not null)
                {

                    return users.Select(MapToUser).ToList();

                }
                return null;
                
            }

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

        public async Task<UserList> RegisterUserAsyn (RegisterUser dto)
        {
            
            TblUser nUser = new() { 
            FirstName = dto.FirstName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            LastName = dto.LastName,
            PasswordHash = pwdHelper.HashPassword(dto.Password)
            
        };
            try {
                await dbContext.TblUsers.AddAsync(nUser);
                await dbContext.SaveChangesAsync();
                var nwuser = await dbContext.VwUsers.Where(x => x.Id == nUser.Id).FirstOrDefaultAsync();

                return MapToUser(nwuser);
                
            }
            catch(Exception ex)
            {

                var apierr = new UserList
                {
                    err = ReturnError(ex, "Account_Registration_Err")
                };
              
                return apierr;
            //ex.InnerException.Message();
        }

           
           
            
        }

        public APIError ReturnError(Exception err, string _source)
        {
            var _error = new APIError()
            {               
                ErrorCode = _source,
                Detail = new List<string>(){ err.InnerException.Message },
                Message= err.Message,
                
            };
            return _error;
        }

        public async Task<UserList> ValidateUserAsyn(ValidateUser dto)
        {

            

            //var _user = await dbContext.TblUsers.Where(x => x.Email == dto.Email).FirstOrDefaultAsync();

            var _user = await dbContext.VwUsers.Where(x => x.Email == dto.Email).FirstOrDefaultAsync();


        //    var _userr = await dbContext.TblUsers.Where(x => x.Email == dto.Email)
        //.Join(
        //    dbContext.TblUserOrganizations,
        //    u => u.Id,
        //    o => o.UserId,
        //    (u, o) => new
        //    {
        //        u.Id,
        //        u.Email,
        //        u.PasswordHash,
        //        u.FirstName,
        //        u.LastName,
        //        u.PhoneNumber,
        //        u.Status,
        //        u.EmailVerified,
        //        o.OrganizationId
        //    }
        //)
        //.FirstOrDefaultAsync();




            if (_user != null)
            {

                if (pwdHelper.VerifyPassword(_user.PasswordHash, dto.Password))
                {

                    return MapToUser(_user);

                }

            }
            return null;
            
        }
         
    }
}

