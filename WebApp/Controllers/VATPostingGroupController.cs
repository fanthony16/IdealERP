using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data.Services.Interface;
using WebApp.Models.Dto;
using WebApp.ViewModels;
using WebApp.WebManager;

namespace WebApp.Controllers
{
    public class VATPostingGroupController : Controller
    {
        private readonly ISessionManager _sessionManager;
        private readonly IVATPostingGroups _vatPostingGroups;

        public VATPostingGroupController(ISessionManager _sessionManager, IVATPostingGroups _vatPostingGroups)
        {
            this._sessionManager = _sessionManager;
            this._vatPostingGroups = _vatPostingGroups;
        }
        [HttpGet("BusVatGroups")]
        public async Task<IActionResult> BusinessVatPostingGroups()
        {
            _sessionManager.SaveSessionObject("VAT Business Posting Groups", "page_title");
            var lstBusVaT = new List<View_VATPostingGroups.VATPostingGroup>();
            var busvatgroup = new View_VATPostingGroups.VATPostingGroup();

            var groupObjs = await _vatPostingGroups.GetVATBusPostingGroupsAsync(_sessionManager.GetSessionObject("organisationid"), _sessionManager.GetSessionObject("companyid"));

            foreach (var obj in groupObjs)
            {
                var vwobj = new View_VATPostingGroups.VATPostingGroup()
                {
                    Id = obj.Id,
                    Code = obj.Code,
                    Description = obj.Description
                };
                lstBusVaT.Add(vwobj);
            }

            busvatgroup.VATPostingGroups = lstBusVaT;

            return View(busvatgroup);

        }
        [HttpGet("ProdVatGroups")]
        public async Task<IActionResult> ProductVatPostingGroups()
        {
            _sessionManager.SaveSessionObject("VAT Product Posting Groups", "page_title");
            var lstProdVaT = new List<View_VATPostingGroups.VATPostingGroup>();
            var prodvatgroup = new View_VATPostingGroups.VATPostingGroup();
           
            var  groupObjs = await _vatPostingGroups.GetVATProdPostingGroupsAsync(_sessionManager.GetSessionObject("organisationid"),_sessionManager.GetSessionObject("companyid"));

            foreach(var obj in groupObjs)
            {
                var vwobj = new View_VATPostingGroups.VATPostingGroup()
                {
                    Id = obj.Id,
                    Code = obj.Code,
                    Description = obj.Description
                };
                lstProdVaT.Add(vwobj);
            }

            prodvatgroup.VATPostingGroups = lstProdVaT;

            return View(prodvatgroup);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductVatPostingGroup(View_VATPostingGroups.VATPostingGroup dto)
        {
            if(dto.Code != "" && dto.Description != "")
            {
                var grpobj = new VATPostingGroups.CreateVATPostingGroup() 
                { 
                    Code = dto.Code,
                    Description = dto.Description,
                    CompanyID = Guid.Parse(_sessionManager.GetSessionObject("companyid")),
                    OrganisationID = Guid.Parse(_sessionManager.GetSessionObject("organisationid"))
                };

                await _vatPostingGroups.CreateVATProdPostingGroupsAsync(grpobj);
            }

          
            _sessionManager.SaveSessionObject("VAT Product Posting Groups", "page_title");

            return RedirectToAction("ProductVatPostingGroups");
        }


        [HttpPost]
        public async Task<IActionResult> CreateBusinessVatPostingGroup(View_VATPostingGroups.VATPostingGroup dto)
        {
            if (dto.Code != "" && dto.Description != "")
            {
                var grpobj = new VATPostingGroups.CreateVATPostingGroup()
                {
                    Code = dto.Code,
                    Description = dto.Description,
                    CompanyID = Guid.Parse(_sessionManager.GetSessionObject("companyid")),
                    OrganisationID = Guid.Parse(_sessionManager.GetSessionObject("organisationid"))
                };

                await _vatPostingGroups.CreateVATBusPostingGroupsAsync(grpobj);

            }


            _sessionManager.SaveSessionObject("VAT Product Posting Groups", "page_title");

            return RedirectToAction("BusinessVatPostingGroups");
        }


        [HttpPost]
        public async Task<IActionResult> UpdateProductVatPostingGroup(View_VATPostingGroups.VATPostingGroup dto)
        {
            if (!string.IsNullOrEmpty(dto.Code) && !string.IsNullOrEmpty(dto.Description))
            {
                var grpobj = new VATPostingGroups.VATPostingGroup()
                {
                    Id = dto.Id,
                    Code = dto.Code,
                    Description = dto.Description,
                    CompanyID = Guid.Parse(_sessionManager.GetSessionObject("companyid")),
                    OrganisationID = Guid.Parse(_sessionManager.GetSessionObject("organisationid"))
                };

                await _vatPostingGroups.UpdateVATProdPostingGroupsAsync(grpobj);
            }


            //_sessionManager.SaveSessionObject("VAT Product Posting Groups", "page_title");

            return RedirectToAction("ProductVatPostingGroups");
        }


        [HttpPost]
        public async Task<IActionResult> UpdateBusinessVatPostingGroup(View_VATPostingGroups.VATPostingGroup dto)
        {
            if (!string.IsNullOrEmpty(dto.Code) && !string.IsNullOrEmpty(dto.Description))
            {
                var grpobj = new VATPostingGroups.VATPostingGroup()
                {
                    Id = dto.Id,
                    Code = dto.Code,
                    Description = dto.Description,
                    CompanyID = Guid.Parse(_sessionManager.GetSessionObject("companyid")),
                    OrganisationID = Guid.Parse(_sessionManager.GetSessionObject("organisationid"))
                };

                await _vatPostingGroups.UpdateVATBusPostingGroupsAsync(grpobj);
            }

            //_sessionManager.SaveSessionObject("VAT Product Posting Groups", "page_title");

            return RedirectToAction("BusinessVatPostingGroups");
        }

        public async Task<JsonResult> GetProductVATGroup(string id)
        {
            try
            {

                var _vatGroup = await _vatPostingGroups.GetVATProdPostingGroupsAsync(_sessionManager.GetSessionObject("organisationid"), _sessionManager.GetSessionObject("companyid"), id.ToString());

                return Json(new { code = _vatGroup.Code, name = _vatGroup.Description, id = _vatGroup.Id });

            }
            catch (Exception e)
            {

                var _vatGroup = new VATPostingGroups.VATPostingGroup();
                return Json(new { code = _vatGroup.Code, name = _vatGroup.Description, id = _vatGroup.Id });

            }


        }

        public async Task<JsonResult> GetBusinessVATGroup(string id)
        {
            try
            {

                var _vatGroup = await _vatPostingGroups.GetVATBusPostingGroupsAsync(_sessionManager.GetSessionObject("organisationid"), _sessionManager.GetSessionObject("companyid"), id.ToString());

                return Json(new { code = _vatGroup.Code, name = _vatGroup.Description, id = _vatGroup.Id });

            }
            catch (Exception e)
            {

                var _vatGroup = new VATPostingGroups.VATPostingGroup();
                return Json(new { code = _vatGroup.Code, name = _vatGroup.Description, id = _vatGroup.Id });

            }


        }

    }
}
