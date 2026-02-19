using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.DTO;

namespace WebAPI.Model.Services.Interface
{
    public interface ICompany
    {
        public Task<Companys.Company> CreateCompanyAsync(Companys.CreateCompany newCompany);

        public Task<Companys.Company> UpdateCompanyAsync(Companys.UpdateCompany company);

        public Task<Companys.Company> EditCompanyAsync(Companys.UpdateCompany editCompany);

        public Task<Companys.Company> GetCompanyAsync(string id, string coyid);

        public Task<List<Companys.Company>> GetOrgCompanysAsync(string id);

    }
}
