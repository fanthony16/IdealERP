using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebApp.Data.Services.Interface;
using WebApp.Models.Dto;
using WebApp.Utilities;
using WebApp.ViewModels;

namespace WebApp.Data.Services.Implementation
{
    public class Companysvr : ICompanys
    {

        private readonly APIGateway _apigateway;

        public Companysvr(APIGateway _apigateway)
        {
            this._apigateway = _apigateway;
        }
        public async Task<Companys.CreateCompany> CreeatCompany(Companys.CreateCompany _company)
        {

           

            throw new NotImplementedException();
        }

        public Task<Companys.Company> GetCompany(string organisationID, string companyID)
        {
            
            throw new NotImplementedException();

        }

        public async Task<List<View_Companys.Company>> GetCompanys(string organisationID)
        {
            var dbCompanys = await _apigateway.ApiGetAsync($"Company/{organisationID}");

            return JsonSerializer.Deserialize<List<View_Companys.Company>>(dbCompanys);

            
        }

        public Task<Companys.Company> updateCompany(Companys.Company _company)
        {
            throw new NotImplementedException();
        }

       

    }
}
