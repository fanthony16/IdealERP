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
            var dbcountryjson = await _apigateway.ApiGetAsync("MasterData/GetAllCountry");
            return JsonSerializer.Deserialize<List<Country>>(dbcountryjson);
            
        }

        public async Task<List<Currency>> GetAllCurrency()
        {
            var dbcurrencyjson = await _apigateway.ApiGetAsync("MasterData/GetAllCurrency");
            return JsonSerializer.Deserialize<List<Currency>>(dbcurrencyjson);
            
        }
    }
}
