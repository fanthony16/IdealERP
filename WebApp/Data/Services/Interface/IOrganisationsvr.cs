using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.Dto;
using WebApp.ViewModels;
using static WebApp.Models.Dto.Organisation;

namespace WebApp.Data.Services
{
    public interface IOrganisationsvr
    {
        Task<Organisation.Organisations> RegisterOrgnaisationAysnc(Organisation.CreateOrganisation dto);

        Task<List<Organisation.Organisations>> GetOrganisationsAsyn();

        Task<List<User.ValidUser>> GetUnAssignedAccountsAsyn();

        Task<List<User.ValidUser>> GetOrganisationAccountsAsyn(Guid Organisationid);

        Task<AssignOganisationOwnerUser> AssignOrganisationOwnerAsyn(AssignOganisationOwnerUser dto);


        //Task<bool> UpdateOrgnaisationAsync(View_Organisation.UpdateOrganisation vwOrg);

    }
}
