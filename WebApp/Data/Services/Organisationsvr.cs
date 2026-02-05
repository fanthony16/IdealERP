using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebApp.Models.Dto;
using WebApp.Utilities;
using WebApp.ViewModels;
using static WebApp.Models.Dto.Organisation;

namespace WebApp.Data.Services
{
    public class Organisationsvr : IOrganisationsvr
    {
        private readonly APIGateway _apigateway;
        public Organisationsvr(APIGateway _apigateway)
        {
            this._apigateway = _apigateway;
        }

        public Task<List<User.ValidUser>> GetOrganisationAccountsAsyn(Guid Organisationid)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Organisation.Organisations>> GetOrganisationsAsyn()
        {

            var Organisations_json = await _apigateway.ApiGetAsync("Registration/GetAllOrganisation");
            return JsonSerializer.Deserialize<List<Organisation.Organisations>>(Organisations_json);


        }

        public async Task<List<User.ValidUser>> GetUnAssignedAccountsAsyn()
        {
            var accounts_json = await _apigateway.ApiGetAsync("User/GetAllUser?AccountType=U");
            return JsonSerializer.Deserialize<List<User.ValidUser>>(accounts_json);
        }

        public async Task<Organisation.Organisations> RegisterOrgnaisationAysnc(Organisation.CreateOrganisation dto)
        {

            var createdOrganisation = await _apigateway.ApiPostAsync<Organisation.CreateOrganisation>(dto, "Registration/CreateOrganisation");

            return JsonSerializer.Deserialize<Organisation.Organisations>(createdOrganisation);


        }

        public Task<bool> UpdateOrgnaisationAsync(View_Organisation.UpdateOrganisation vwOrg)
        {
            throw new NotImplementedException();
        }

        public async Task<AssignOganisationOwnerUser> AssignOrganisationOwnerAsyn(AssignOganisationOwnerUser dto)
        {

            var createdOrganisation = await _apigateway.ApiPostAsync<Organisation.AssignOganisationOwnerUser>(dto, "Registration/TanentOwner");

            return JsonSerializer.Deserialize<Organisation.AssignOganisationOwnerUser>(createdOrganisation);

            //return null;
        }
    }
}
