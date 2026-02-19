using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ViewModels;
using static WebApp.Models.Dto.Companys;

namespace WebApp.Data.Services.Interface
{
    public interface ICompanys
    {
        
        Task<List<View_Companys.UpdateCompany>> GetCompanys(string organisationID);

        Task<View_Companys.UpdateCompany> GetCompanyAsync(string organisationID, string companyID);

        Task<CreateCompany> CreeatCompany(CreateCompany _company);

        Task<bool> UpdateCompany(View_Companys.UpdateCompany company);

    }
}
