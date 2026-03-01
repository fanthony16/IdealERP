using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebApp.Models.Dto.MasterData;

namespace WebApp.Data.Services
{
    public interface IMasterData
    {
        public Task<List<Country>> GetAllCountry();

        public Task<List<Currency>> GetAllCurrency();

        public Task<List<SelectListItem>> GetSelectListCurrency();

        public Task<List<SelectListItem>> GetSelectListCountry();
    }
}
