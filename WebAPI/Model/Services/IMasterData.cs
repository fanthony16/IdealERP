using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebAPI.Model.DTO.MasterData;

namespace WebAPI.Model.Services
{
    public interface IMasterData
    {
        Task<List<Country>> GetAllCountryAsync();

        Task<List<Currency>> GetAllCurrencyAsync();
    }
}
