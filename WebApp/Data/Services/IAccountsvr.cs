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
        public Task<bool> ValidateAccount(ValidateUser _loginaccount);

        public Task<bool> RegisterAccount(Register _newaccount);

        public Task<bool> UpdateAccount(Register _editaccount);

    }
}
