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

        public async Task<View_ChartLedgerAccount.LedgerAccount> GetLedgerAccountAsync(string organisationID, string companyID, string ledgerid)
        {
            var result = await _apigateway.ApiGetAsync($"AccountChart/accounts/{organisationID}/{companyID}/{ledgerid}");

            try 
            {
                var ledgeraccount = JsonSerializer.Deserialize<View_ChartLedgerAccount.LedgerAccount>(result);
                return ledgeraccount;
            }
            catch
            {
                return new View_ChartLedgerAccount.LedgerAccount();
            }
            
        }

        public async Task<List<View_ChartLedgerAccount.LedgerAccount>> GetLedgerAccountsAsync(string organisationID, string companyID)
        {
            
            var result = await _apigateway.ApiGetAsync($"AccountChart/accounts/{organisationID}/{companyID}");

            try
            {
                var ledgeraccounts = JsonSerializer.Deserialize<List<View_ChartLedgerAccount.LedgerAccount>>(result);


                foreach (var acc in ledgeraccounts)
                {
                    acc.IncomeBalance = (acc.IncomeBalance == "1") ? "Income Statement" : "Balance Sheet";

                    switch(acc.AccountType)
                    {
                        case "1":
                            acc.AccountType = "Posting";
                            break;
                        case "2":
                            acc.AccountType = "Heading";
                            break;
                        case "3":
                            acc.AccountType = "Total";
                            break;
                        case "4":
                            acc.AccountType = "Begin Total";
                            break;
                        case "5":
                            acc.AccountType = "End Total";
                            break;
                        default:
                            break;
                    }

                }


                return ledgeraccounts;
            }
            catch
            {
                return new List<View_ChartLedgerAccount.LedgerAccount>();
            }
        }

        public async Task<bool> UpdateLeagerAccountAsync(View_ChartLedgerAccount.LedgerAccount ledgerAccount)
        {
            var result = await _apigateway.ApiPostAsync<View_ChartLedgerAccount.LedgerAccount>(ledgerAccount, "AccountChart/accounts/Edit");

            try
            {
                var ledgeraccount = JsonSerializer.Deserialize<View_ChartLedgerAccount.LedgerAccount>(result);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
