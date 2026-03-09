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

        public Task<bool> UpdateLeagerAccountAsync(View_ChartLedgerAccount.UpdateLedgerAccount ledgerAccount);

        public Task<List<View_ChartLedgerAccount.CreateLedgerAccount>> GetLeagerAccountsAsync(string organisationID);

        public Task<View_ChartLedgerAccount.CreateLedgerAccount> GetLeagerAccountAsync(string organisationID,string companyID);
    }
}
