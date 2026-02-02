using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using static WebAPI.Model.DTO.Organisation;
using static WebAPI.Model.DTO.User;

namespace WebAPI.Model.Services
{
    public interface IOrganisationsvr
    {
        public Task<Organisations> CreateOrganisationAsync(CreateOrganisation dto);

        public Task<bool> UpdateOrganisationAsync(UpdateOrganisation dto);

        public Task<List<Organisations>> GetAllOrganisationAsync();

        Task<AssignOganisationOwnerUser> CreateTenantOwnerAsyn(AssignOganisationOwnerUser dto);




    }
}
