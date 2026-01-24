using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Model.Services;
using static WebAPI.Model.DTO.MasterData;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {
        private readonly IdealERPContext dbContext;
        private readonly IMasterData masterData;
        public MasterDataController(IdealERPContext dbContext, IMasterData masterData)
        {
            this.dbContext = dbContext;
            this.masterData = masterData;
        }

        [HttpGet("GetAllCountry")]
        public async Task<List<Country>> GetCountries()
        {
            return await masterData.GetAllCountryAsync();
        }

        [HttpGet("GetAllCurrency")]
        public async Task<List<Currency>> GetCurrencies()
        {
            return await masterData.GetAllCurrencyAsync();
        }
    }
}
