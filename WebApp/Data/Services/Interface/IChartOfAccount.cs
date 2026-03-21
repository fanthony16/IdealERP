using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Data.Services.Interface
{
    public interface IChartOfAccount
    {
        public Task<bool> CreateLeagerAccountAsync(View_ChartLedgerAccount.CreateLedgerAccount nwledgerAccount);

        public Task<bool> UpdateLeagerAccountAsync(View_ChartLedgerAccount.LedgerAccount ledgerAccount);

        public Task<List<View_ChartLedgerAccount.LedgerAccount>> GetLedgerAccountsAsync(string organisationID, string companyID);

        public Task<View_ChartLedgerAccount.LedgerAccount> GetLedgerAccountAsync(string organisationID,string companyID, string ledgerid);
    }
}
