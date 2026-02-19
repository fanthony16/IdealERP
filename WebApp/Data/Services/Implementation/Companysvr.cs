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

        public async Task<View_Companys.UpdateCompany> GetCompanyAsync(string organisationID, string companyID)
        {
            var dbCompanys = await _apigateway.ApiGetAsync($"Company/Find/?id={organisationID}&coyid={companyID}");

            return JsonSerializer.Deserialize<View_Companys.UpdateCompany>(dbCompanys);
            

        }

        public async Task<List<View_Companys.UpdateCompany>> GetCompanys(string organisationID)
        {
            var dbCompanys = await _apigateway.ApiGetAsync($"Company/{organisationID}");

            return JsonSerializer.Deserialize<List<View_Companys.UpdateCompany>>(dbCompanys);

            
        }

        public async Task<bool> UpdateCompany(View_Companys.UpdateCompany company)
        {

            var result = await _apigateway.ApiPostAsync<View_Companys.UpdateCompany>(company, "Company/Update");

            try
            {
                var updatedcompany = JsonSerializer.Deserialize<View_Companys.UpdateCompany>(result);
                return true;
            }
            catch 
            {
                return false;               
            }
            

            
            
        }

       

    }
}
