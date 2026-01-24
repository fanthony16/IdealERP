using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebAPI.Model.DTO.User;

namespace WebAPI.Model.Services
{
    public interface IUser
    {
        Task<UserList> CreateUserAsync(RegisterUser dto);

        Task<List<UserList>> GetAllUsersAsync();

        Task<UserList> GetAllUserByIdAsync(Guid id);

        Task<bool> UpdateUser(Guid id, UpdateUser dto);

        Task<bool> RegisterUserAsyn(RegisterUser dto);

        Task<bool> ValidateUserAsyn(ValidateUser dto);

    }
}
