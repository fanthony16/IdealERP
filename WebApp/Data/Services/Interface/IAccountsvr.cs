using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.Dto;
using static WebApp.ViewModels.Account;

namespace WebApp.Data.Services
{
    public interface IAccountsvr
    {
        public Task<User.ValidUser> ValidateAccount(User.ValidateUser _loginaccount);

        public Task<User.ValidUser> RegisterAccount(Register _newaccount);

        public Task<User.ValidUser> UpdateAccount(Register _editaccount);

    }
}
