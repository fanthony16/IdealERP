using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebApp.Data.Services.Interface;
using WebApp.Utilities;
using WebApp.ViewModels;

namespace WebApp.Data.Services.Implementation
{
    public class ChartOfAccountsvr : IChartOfAccount
    {
        private readonly APIGateway _apigateway;

        public ChartOfAccountsvr(APIGateway _apigateway)
        {
            this._apigateway = _apigateway;
        }

        public async Task<bool> CreateLeagerAccountAsync(View_ChartLedgerAccount.CreateLedgerAccount nwledgerAccount)
        {

            var result = await _apigateway.ApiPostAsync<View_ChartLedgerAccount.CreateLedgerAccount>(nwledgerAccount, "AccountChart/accounts/New");

            try
            {
                var createdcompany = JsonSerializer.Deserialize<View_ChartLedgerAccount.CreateLedgerAccount>(result);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<View_ChartLedgerAccount.CreateLedgerAccount> GetLeagerAccountAsync(string organisationID, string companyID)
        {

            var result = await _apigateway.ApiGetAsync("Company/New");
            try
            {
                var ledgeraccount = JsonSerializer.Deserialize<View_ChartLedgerAccount.CreateLedgerAccount>(result);
                return ledgeraccount;
            }
            catch
            {
                return null;
            }

            
        }

        public async Task<List<View_ChartLedgerAccount.CreateLedgerAccount>> GetLeagerAccountsAsync(string organisationID)
        {

            var result = await _apigateway.ApiGetAsync("Company/New");

            try
            {
                var ledgeraccounts = JsonSerializer.Deserialize<List<View_ChartLedgerAccount.CreateLedgerAccount>>(result);
                return ledgeraccounts;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateLeagerAccountAsync(View_ChartLedgerAccount.UpdateLedgerAccount ledgerAccount)
        {
            var result = await _apigateway.ApiPostAsync<View_ChartLedgerAccount.CreateLedgerAccount>(ledgerAccount, "Company/New");

            try
            {
                var ledgeraccount = JsonSerializer.Deserialize<View_ChartLedgerAccount.CreateLedgerAccount>(result);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
