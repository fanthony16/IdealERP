using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Services.Interface;
using WebApp.Utilities;
using WebApp.ViewModels;
using WebApp.WebManager;

namespace WebApp.Controllers
{
    public class CompanyController : Controller
    {

        private readonly ICompanys _companys;
        private readonly ISessionManager _sessionManager;
        public CompanyController(ICompanys _companys, ISessionManager _sessionManager)
        {
            this._companys = _companys;
            this._sessionManager = _sessionManager;
        }
        public async Task<IActionResult> Index()
        {
            
            var lstCompanys = await _companys.GetCompanys(_sessionManager.GetSessionObject("organisationid"));
            _sessionManager.SaveSessionObject("Companys", "page_title");
            return View(lstCompanys);

        }

        public async Task<IActionResult> Edit(string id) {

            if (!string.IsNullOrEmpty(id))
            {
                _sessionManager.SaveSessionObject(id, "companyid");
              var company =  await _companys.GetCompanyAsync(_sessionManager.GetSessionObject("organisationid"), id);
                _sessionManager.SaveSessionObject("Company Information", "page_title");
                return View(company);
            }
            return View(new View_Companys.UpdateCompany());
            
        }
        [HttpPost]
        public async Task<IActionResult> Edit(View_Companys.UpdateCompany company)
        {

            if (ModelState.IsValid)
            {
                company.OrganisationId = Guid.Parse(_sessionManager.GetSessionObject("organisationid"));
                company.CompanyID = Guid.Parse(_sessionManager.GetSessionObject("companyid"));
                var _company = await _companys.UpdateCompany(company);
                //_sessionManager.SaveSessionObject("Company Information", "page_title");
                return RedirectToAction("Index");
            }
            return View(new View_Companys.UpdateCompany());

        }
    }
}
