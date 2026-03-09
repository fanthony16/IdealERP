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

        public IActionResult Index()
        {
            return View();
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
                var status =  await _ledgeraccount.CreateLeagerAccountAsync(nwledgerAccount);

            }
            else
            {
                return View(ModelState);
            }

            return RedirectToAction("Index");

        }
    }
}
