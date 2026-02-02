using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using static WebAPI.Model.DTO.User;

namespace WebAPI.Model.Services
{
    public interface IUser
    {
        Task<UserList> CreateUserAsync(RegisterUser dto);

        //A= All Users
        //U= UnAssigned Users
        Task<List<UserList>> GetAllUsersAsync(char userCategory);



        Task<UserList> GetAllUserByIdAsync(Guid id);

        Task<bool> UpdateUser(Guid id, UpdateUser dto);

        Task<UserList> RegisterUserAsyn(RegisterUser dto);

        Task<UserList> ValidateUserAsyn(ValidateUser dto);

        
        
    }
}
