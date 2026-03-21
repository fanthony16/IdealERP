using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Services.Interface;
using WebApp.ViewModels;
using WebApp.WebManager;

namespace WebApp.Controllers
{
    public class AccountChartController : Controller
    {
        
        private readonly ISessionManager _sessionManager;
        private readonly IChartOfAccount _ledgeraccount;

        public AccountChartController(ISessionManager _sessionManager, IChartOfAccount _ledgeraccount)
        {
            this._sessionManager = _sessionManager;
            this._ledgeraccount = _ledgeraccount;
        }

        public async Task<IActionResult> Index()
        {


            var ledgeraacount = await _ledgeraccount.GetLedgerAccountsAsync(_sessionManager.GetSessionObject("organisationid"), _sessionManager.GetSessionObject("companyid"));
            _sessionManager.SaveSessionObject("Chart Of Accounts", "page_title");

            return View(ledgeraacount);
        }


        public async Task<IActionResult> Edit(Guid id)
        {

            var ledgeraacount = await _ledgeraccount.GetLedgerAccountAsync(_sessionManager.GetSessionObject("organisationid"), _sessionManager.GetSessionObject("companyid"),id.ToString());

            _sessionManager.SaveSessionObject("Chart Of Accounts", "page_title");

            return View(ledgeraacount);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(View_ChartLedgerAccount.LedgerAccount nwledgerAccount)
        {

            if (ModelState.IsValid)
            {
                
                nwledgerAccount.OrganisationID = Guid.Parse(_sessionManager.GetSessionObject("organisationid"));
                nwledgerAccount.CompanyID = Guid.Parse(_sessionManager.GetSessionObject("companyid"));

                var leageraccount = await _ledgeraccount.UpdateLeagerAccountAsync(nwledgerAccount);

                return RedirectToAction("Index");

            }

            return View(nwledgerAccount);

        }


        public IActionResult Create()
        {
            _sessionManager.SaveSessionObject("Create Ledger Account ", "page_title");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(View_ChartLedgerAccount.CreateLedgerAccount nwledgerAccount)
        {

            if (ModelState.IsValid)
            {

                nwledgerAccount.OrganisationID = Guid.Parse(_sessionManager.GetSessionObject("organisationid"));
                nwledgerAccount.CompanyID = Guid.Parse(_sessionManager.GetSessionObject("companyid"));
                nwledgerAccount.Balance = 0;
                var status =  await _ledgeraccount.CreateLeagerAccountAsync(nwledgerAccount);

            }
            else
            {
                return View(nwledgerAccount);
            }

            return RedirectToAction("Index");

        }
    }
}
