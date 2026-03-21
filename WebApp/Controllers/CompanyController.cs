using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Services;
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
        private readonly FileUploadProcessor fileprocessor;
        private readonly IWebHostEnvironment _env;
        private readonly IMasterData masterdata;


        public CompanyController(ICompanys _companys, ISessionManager _sessionManager, FileUploadProcessor fileprocessor, IWebHostEnvironment _env, IMasterData masterdata)
        {
            this._companys = _companys;
            this._sessionManager = _sessionManager;
            this.fileprocessor = fileprocessor;
            this._env = _env;
            this.masterdata = masterdata;
        }
        
        public async Task<IActionResult> Index()
        {
            
            var lstCompanys = await _companys.GetCompanysAsync(_sessionManager.GetSessionObject("organisationid"));

            var defaultcompany = lstCompanys.Where(c => c.isDefault == true).FirstOrDefault().Name;
                                 
            if (!string.IsNullOrEmpty(defaultcompany))
            {
                _sessionManager.SaveSessionObject(defaultcompany, "active_company");
            }


            _sessionManager.SaveSessionObject("Companys", "page_title");
            return View(lstCompanys);

        }

        public async Task<IActionResult> Create() 
        {
            var nwCompany = new View_Companys.CreateCompany {

                Countries = await masterdata.GetSelectListCountry(),
                PictureUrl = "/" + Path.GetRelativePath(_env.WebRootPath, "/img/companylogo/defaultcompany.PNG")
        .Replace("\\", "/")

        };
            _sessionManager.SaveSessionObject("New Company Creation", "page_title");

            return View(nwCompany);

        }
        [HttpPost]
        public async Task<IActionResult> Create(View_Companys.CreateCompany _company)
        {


            if (!ModelState.IsValid)
            {
                return View(_company);
            }
            _company.OrganisationId = Guid.Parse(_sessionManager.GetSessionObject("organisationid"));
            

            if (_company.CompanyLogoFile?.Length > 0)
            {
                var logoPath = fileprocessor.SaveToFolder(_env.WebRootPath + "\\img\\companylogo", _company.CompanyLogoFile, _company.Name.Replace(" ",""));
                _company.PictureUrl = "/" + Path.GetRelativePath(_env.WebRootPath, logoPath).Replace("\\", "/");

            }

            _company.PictureUrl = _sessionManager.GetSessionObject("companylogopath");
            _sessionManager.RemoveSessionObject("companylogopath");


            var status = await _companys.CreateCompany(_company);
            return RedirectToAction("Index");

        }


        public async Task<IActionResult> Edit(string id) {

            if (!string.IsNullOrEmpty(id))
            {
                _sessionManager.SaveSessionObject(id, "companyid");
              var company =  await _companys.GetCompanyAsync(_sessionManager.GetSessionObject("organisationid"), id);

                
                if (company.PictureUrl is not null)
                {
                    _sessionManager.SaveSessionObject(company.PictureUrl, "companylogopath");
                }

                _sessionManager.SaveSessionObject("Company Information", "page_title");

                company.PictureUrl ??= "/" + Path.GetRelativePath(_env.WebRootPath, "/img/companylogo/defaultcompany.PNG")
        .Replace("\\", "/");

              
                company.Countries = await masterdata.GetSelectListCountry();


                return View(company);
            }
            return View(new View_Companys.UpdateCompany());
            
        }


        public async Task<IActionResult> SetDefault(string id)
        {

            if (!string.IsNullOrEmpty(id))
            {
                _sessionManager.SaveSessionObject(id, "companyid");
                

                var company = await _companys.SwitchCompany(_sessionManager.GetSessionObject("organisationid"), id);

                return RedirectToAction("Index");

            }
                
            return RedirectToAction("Index");

        }


        [HttpPost]
        public async Task<IActionResult> Edit(View_Companys.UpdateCompany company)
        {

            if (ModelState.IsValid)
            {

                if (company.CompanyLogoFile?.Length > 0)
                {

                    

                    var logoPath = fileprocessor.SaveToFolder(_env.WebRootPath + "\\img\\companylogo", company.CompanyLogoFile, company.Name.Replace(" ","")+ Path.GetExtension(company.CompanyLogoFile.FileName));
                    company.PictureUrl = "/" + Path.GetRelativePath(_env.WebRootPath, logoPath).Replace("\\", "/");



                }
                else
                {
                    company.PictureUrl = _sessionManager.GetSessionObject("companylogopath");
                }
                
                _sessionManager.RemoveSessionObject("companylogopath");

                company.OrganisationId = Guid.Parse(_sessionManager.GetSessionObject("organisationid"));
                company.CompanyID = Guid.Parse(_sessionManager.GetSessionObject("companyid"));
                var _company = await _companys.UpdateCompany(company);

                
                return RedirectToAction("Index");
            }

            return View(new View_Companys.UpdateCompany());

        }
    }
}
