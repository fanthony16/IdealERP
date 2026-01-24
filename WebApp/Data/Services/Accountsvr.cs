using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebApp.Models.Dto;
using WebApp.Utilities;
using WebApp.ViewModels;
using static WebApp.ViewModels.Account;

namespace WebApp.Data.Services
{
    public class Accountsvr : IAccountsvr
    {
        private readonly APIGateway _apigateway;
        public Accountsvr(APIGateway _apigateway)
        {
            this._apigateway = _apigateway;
        }
        public async Task<bool> ValidateAccount(ValidateUser _loginaccount)
        {

            var _status = await _apigateway.ApiPostAsync<ValidateUser>(_loginaccount, "User/ValidateUser");
            return _status;

        }

        public async Task<bool> RegisterAccount(Register _newaccount)
        {
            var nwUser = new User
            {
                Email = _newaccount.Email,
                FirstName = _newaccount.First_name,
                LastName = _newaccount.Last_name,
                Password = _newaccount.Password,
                PhoneNumber = _newaccount.Telephone

            };
            //call api and make a post request for account creation
            var _status = await _apigateway.ApiPostAsync<User>(nwUser, "User/RegisterUser");
            return _status;

        }

        public Task<bool> UpdateAccount(ViewModels.Account.Register _editaccount)
        {
            throw new NotImplementedException();
        }

    }


    
}
