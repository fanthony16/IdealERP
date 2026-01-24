using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using static WebAPI.Model.DTO.MasterData;

namespace WebAPI.Model.Services
{
    public class MasterData : IMasterData

         

    {
        private readonly IdealERPContext dbcontext;

        public MasterData(IdealERPContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        private Country MapToCountry(TblCountry dbcountry)
        {
            var _country = new Country
            {
                Code = dbcountry.CountryCode,
                Name = dbcountry.CountryName
            };
            return _country;
        }

        private Currency MapToCurrency(TblCurrency dbcurrency)
        {
            var _currency = new Currency
            {
                Code = dbcurrency.Code,
                Description = dbcurrency.Description
            };
            return _currency;
        }

        public async Task<List<Country>> GetAllCountryAsync()
        {
            var dbcountries = await dbcontext.TblCountries.ToListAsync();

            if (dbcountries != null) {
                return dbcountries.Select(MapToCountry).ToList();
            }
            return new List<Country>();
        }

        public async Task<List<Currency>> GetAllCurrencyAsync()
        {
            var dbcurrencies = await dbcontext.TblCurrencies.ToListAsync();

            if (dbcurrencies != null)
            {
                return dbcurrencies.Select(MapToCurrency).ToList();
            }
            return new List<Currency>();
        }
    }
}
