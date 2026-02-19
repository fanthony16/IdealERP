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
        
        Task<List<View_Companys.Company>> GetCompanys(string organisationID);

        Task<Company> GetCompany(string organisationID, string companyID);

        Task<CreateCompany> CreeatCompany(CreateCompany _company);

        Task<Company> updateCompany(Company _company);

    }
}
