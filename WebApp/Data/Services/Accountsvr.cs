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
        public async Task<User.ValidUser> ValidateAccount(User.ValidateUser _loginaccount)
        {

            var _validatedUser = await _apigateway.ApiPostAsync<User.ValidateUser>(_loginaccount, "User/ValidateUser");

            return JsonSerializer.Deserialize<User.ValidUser>(_validatedUser);

        }

        public async Task<User.ValidUser> RegisterAccount(Register _newaccount)
        {
            var nwUser = new User.CreateUser
            {
                Email = _newaccount.Email,
                FirstName = _newaccount.First_name,
                LastName = _newaccount.Last_name,
                Password = _newaccount.Password,
                PhoneNumber = _newaccount.Telephone,
                
            };
            //call api and make a post request for account creation
            var _validatedUser = await _apigateway.ApiPostAsync<User.CreateUser>(nwUser, "User/RegisterUser");
            return JsonSerializer.Deserialize<User.ValidUser>(_validatedUser);
            


            

        }

      

        public Task<User.ValidUser> UpdateAccount(Register _editaccount)
        {
            throw new NotImplementedException();
        }
    }


    
}
