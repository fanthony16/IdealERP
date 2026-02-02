using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Services;
using WebApp.ViewModels;
using WebApp.Models.Dto;
using static WebApp.Models.Dto.MasterData;
using WebApp.WebManager;
using static WebApp.Models.Dto.Organisation;

namespace WebApp.Controllers
{
    public class OrganisationController : Controller
    {
        private readonly IMasterData masterdata;
        private readonly IOrganisationsvr org_registration;
        private readonly ISessionManager _sessionManager;
        private readonly IAccountsvr _accountsvr;

        public OrganisationController(IMasterData masterdata, IOrganisationsvr org_registration, ISessionManager _sessionManager, IAccountsvr _accountsvr)
        {
            this.masterdata = masterdata;
            this.org_registration = org_registration;
            this._sessionManager = _sessionManager;
            this._accountsvr = _accountsvr;
        }


        private View_Organisation.OrganisationObj MapToView(Organisation.Organisations dto)
        {
            var orgObj = new View_Organisation.OrganisationObj
            {

                Id = dto.Id,
                Legal_name = dto.Legal_name,
                Country = dto.CountryName,
                Currency =dto.CurrencyType,
                Industry = dto.Industry,
                AcceptTerms = dto.AcceptTerms
                

            };
            return orgObj;
        }

        public async Task<IActionResult> Index()
        {

            var dblstOrgs = await org_registration.GetOrganisationsAsyn();
            var dblstUnassignedOrgAccounts = await org_registration.GetUnAssignedAccountsAsyn();

            var SelectListData = await getSelectedListItemDataAsync();
            var lstOrgs = dblstOrgs.Select(MapToView).ToList();
            var vworg = new View_Organisation.OrganisationObj()
            {
                Orgs = lstOrgs,
                Countries = SelectListData[0],
                Currencies = SelectListData[1],
                AllUnAssignedAccounts = dblstUnassignedOrgAccounts
            };
            
            return View(vworg);

        }

        public async Task<IActionResult> Register() {

            var SelectListData = await getSelectedListItemDataAsync();

            var vworg = new View_Organisation.Create_Organisation()
            {
                
                Countries = SelectListData[0],
                Currencies = SelectListData[1]

            };

            _sessionManager.SaveSessionObject("Organization Registration", "page_title");

            return View(vworg);

            
        }

        public IActionResult Dashboard()
        {
            _sessionManager.SaveSessionObject("Organization Subcription Management", "page_title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(View_Organisation.Create_Organisation vwOrg)
        {
            if (ModelState.IsValid)
            {
                var dto = new Organisation.CreateOrganisation
                {
                    Legal_name = vwOrg.Legal_name,
                    CountryName = vwOrg.Country,
                    CurrencyType = vwOrg.Currency,
                    Industry = vwOrg.Industry,
                    Business_Email = vwOrg.Business_email,
                    AcceptTerms = vwOrg.AcceptTerms
                    
                };

                var createdOrganisation = await org_registration.RegisterOrgnaisationAysnc(dto);

                if (createdOrganisation is null)
                {
                    var SelectListData = await getSelectedListItemDataAsync();

                    var vworg = new View_Organisation.Create_Organisation()
                    {

                        Countries = SelectListData[0],
                        Currencies = SelectListData[1]

                    };
                    ViewBag["Message"] = "An Error Occur Creating Organisation. Try again";
                    
                    return View(vworg);
                }

                    _sessionManager.SaveSessionObject(createdOrganisation.Id.ToString(), "tenantid");

            }

            await AssignOrganisationOwner();

            return RedirectToAction("Dashboard");

        }

        private async Task<bool> AssignOrganisationOwner()
        {
            
            var orgOwner = new AssignOganisationOwnerUser
            {

                OrganisationID = Guid.Parse(_sessionManager.GetSessionObject("tenantid")),
                UserID = Guid.Parse(_sessionManager.GetSessionObject("userid"))
            
            };

          var assignedUser =  await org_registration.AssignOrganisationOwnerAsyn(orgOwner);

            if (assignedUser != null)
            {
                return true;
            }
            return false;
        }

        private async Task<List<List<SelectListItem>>> getSelectedListItemDataAsync()
        {
            List<Country> countries = await masterdata.GetAllCountry();
            List<Currency> currencies = await masterdata.GetAllCurrency();

            var SelectlstCountry = countries.ToList().ConvertAll(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Code
            });

            var SelectlstCurrency = currencies.ToList().ConvertAll(x => new SelectListItem
            {
                Text = x.Code + " - " + x.Description,
                Value = x.Code
            });

            var vworg = new View_Organisation.Create_Organisation()
            {

                Countries = SelectlstCountry,
                Currencies = SelectlstCurrency

            };

            var listSelectedItems = new List<List<SelectListItem>>
                {
                    SelectlstCountry,
                    SelectlstCurrency
                };


            return listSelectedItems;
        }
    }
}
