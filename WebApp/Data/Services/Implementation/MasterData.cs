using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebApp.Models.Dto;
using WebApp.Utilities;
using static WebApp.Models.Dto.MasterData;

namespace WebApp.Data.Services
{
    public class MasterData : IMasterData
    {
        private readonly APIGateway _apigateway;
        public MasterData(APIGateway _apigateway)
        {
            this._apigateway = _apigateway;
        }
        public async Task<List<Country>> GetAllCountry()
        {
            var dbcountryjson = await _apigateway.ApiGetAsync("MasterData/Countries");

            return JsonSerializer.Deserialize<List<Country>>(dbcountryjson);
            
        }

        public async Task<List<Currency>> GetAllCurrency()
        {
            var dbcurrencyjson = await _apigateway.ApiGetAsync("MasterData/Currencies");
            return JsonSerializer.Deserialize<List<Currency>>(dbcurrencyjson);
            
        }

        public async Task<List<SelectListItem>> GetSelectListCurrency()
        {
            var dbcurrencyjson = await _apigateway.ApiGetAsync("MasterData/Currencies");
            var currencies = JsonSerializer.Deserialize<List<Currency>>(dbcurrencyjson);
            var selectListCurrency = currencies.ToList().ConvertAll(x => new SelectListItem
            {

                Text = x.Code + " - " + x.Description,
                Value = x.Code

            });
            return selectListCurrency;

        }

        public async Task<List<SelectListItem>> GetSelectListCountry()
        {

            var dbcurrencyjson = await _apigateway.ApiGetAsync("MasterData/Countries");
            var countries = JsonSerializer.Deserialize<List<Country>>(dbcurrencyjson);

            var selectListCountry = countries.ToList().ConvertAll(x => new SelectListItem 
            {
                Text = x.Name,
                Value = x.Code
            });

            return selectListCountry;
        }
     
    }
}
