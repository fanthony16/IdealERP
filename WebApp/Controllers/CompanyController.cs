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


            return View(lstCompanys);
        }
    }
}
