using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.DTO;

namespace WebAPI.Model.Services.Interface
{
    public interface IAccountChart
    {
        public Task<ChartLedgerAccount.LedgerAccount> CreateAsync(ChartLedgerAccount.CreateLedgerAccount dto);

        public Task<ChartLedgerAccount.LedgerAccount> UpdateAsync(ChartLedgerAccount.UpdateLedgerAccount dto);

        public Task<List<ChartLedgerAccount.LedgerAccount>> GetLedgerAccountsAsync(string orgid, string coyid);

    }
}
