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
        
        Task<List<View_Companys.GetCompanys>> GetCompanysAsync(string organisationID);

        Task<View_Companys.GetCompanys> GetCompanyAsync(string organisationID, string companyID);

        Task<bool> CreateCompany(View_Companys.CreateCompany company);

        Task<bool> UpdateCompany(View_Companys.UpdateCompany company);

    }
}
