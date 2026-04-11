using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class GenPostingGroupController : Controller
    {
        private readonly ISessionManager _sessionManager;
        private readonly IGenPostingGroups _genPostingGroups;
        private readonly IVATPostingGroups _vatPostingGroups;

        public GenPostingGroupController(ISessionManager _sessionManager, IGenPostingGroups _genPostingGroups, IVATPostingGroups _vatPostingGroups)
        {
            this._sessionManager = _sessionManager;
            this._genPostingGroups = _genPostingGroups;
            this._vatPostingGroups = _vatPostingGroups;
        }
        [HttpGet("GenBusGroups")]
        public async Task<IActionResult> GenBusinessPostingGroups()
        {
            _sessionManager.SaveSessionObject("Gen. Business Posting Groups", "page_title");

            var lstGenBus = new List<View_GenPostingGroups.GenPostingGroup>();

            var genbusgroup = new View_GenPostingGroups.GenPostingGroup();

            var vatgrps = await _vatPostingGroups.GetVATBusPostingGroupsAsync(_sessionManager.GetSessionObject("organisationid"), _sessionManager.GetSessionObject("companyid"));

            var lstVats = vatgrps.ToList().ConvertAll(x => new SelectListItem
            {
                Text = x.Description,
                Value = x.Id.ToString()
            });

           // var ss = lstVats.Where(x => x.Value == "").FirstOrDefault().Text;

            var postinggroupObjs = await _genPostingGroups.GetGenBusPostingGroupsAsync(_sessionManager.GetSessionObject("organisationid"), _sessionManager.GetSessionObject("companyid"));

            foreach (var obj in postinggroupObjs)
            {
                if (lstVats.Where(x => x.Value == obj.VatID.ToString()).ToList().Count == 0)
                {
                    var vwobj = new View_GenPostingGroups.GenPostingGroup()
                    {
                        Id = obj.Id,
                        Code = obj.Code,
                        Description = obj.Description,
                        VatName = ""

                    };
                    lstGenBus.Add(vwobj);
                }
                else
                {
                    var vwobj = new View_GenPostingGroups.GenPostingGroup()
                    {
                        Id = obj.Id,
                        Code = obj.Code,
                        Description = obj.Description,
                        VatName = lstVats.Where(x => x.Value == obj.VatID.ToString()).FirstOrDefault().Text

                    };
                    lstGenBus.Add(vwobj);
                }
            }

            genbusgroup.GenPostingGroups = lstGenBus;
            genbusgroup.VatGroups = lstVats;

            return View(genbusgroup);

        }
        [HttpGet("GenProdGroups")]
        public async Task<IActionResult> GenProductPostingGroups()
        {
            _sessionManager.SaveSessionObject("Gen Product Posting Groups", "page_title");
            var lstGenProd = new List<View_GenPostingGroups.GenPostingGroup>();
            var genprodgroup = new View_GenPostingGroups.GenPostingGroup();
            
            var postinggroupObjs = await _genPostingGroups.GetGenProdPostingGroupsAsync(_sessionManager.GetSessionObject("organisationid"), _sessionManager.GetSessionObject("companyid"));

            var vatgrps = await _vatPostingGroups.GetVATProdPostingGroupsAsync(_sessionManager.GetSessionObject("organisationid"), _sessionManager.GetSessionObject("companyid"));

            var lstVats = vatgrps.ToList().ConvertAll(x => new SelectListItem
            {
                Text = x.Description,
                Value = x.Id.ToString()
            });

            foreach (var obj in postinggroupObjs)
            {

                if (lstVats.Where(x => x.Value == obj.VatID.ToString()).ToList().Count == 0)
                {
                    var vwobj = new View_GenPostingGroups.GenPostingGroup()
                    {
                        Id = obj.Id,
                        Code = obj.Code,
                        Description = obj.Description,
                        VatName = ""

                    };
                    lstGenProd.Add(vwobj);
                }
                else
                {
                    var vwobj = new View_GenPostingGroups.GenPostingGroup()
                    {
                        Id = obj.Id,
                        Code = obj.Code,
                        Description = obj.Description,
                        VatName = lstVats.Where(x => x.Value == obj.VatID.ToString()).FirstOrDefault().Text

                    };
                    lstGenProd.Add(vwobj);
                }


                
                
            }

            genprodgroup.GenPostingGroups = lstGenProd;
            genprodgroup.VatGroups = lstVats;

            return View(genprodgroup);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductGenPostingGroup(View_GenPostingGroups.GenPostingGroup dto)
        {
            if (dto.Code != "" && dto.Description != "")
            {
                var grpobj = new GenPostingGroups.CreateGenPostingGroup()
                {
                    Code = dto.Code,
                    Description = dto.Description,
                    CompanyID = Guid.Parse(_sessionManager.GetSessionObject("companyid")),
                    OrganisationID = Guid.Parse(_sessionManager.GetSessionObject("organisationid")),
                    VatID = dto.VatID
                };

                await _genPostingGroups.CreateGenProdPostingGroupsAsync(grpobj);
            }


            _sessionManager.SaveSessionObject("Gen Product Posting Groups", "page_title");

            return RedirectToAction("GenProductPostingGroups");
        }


        [HttpPost]
        public async Task<IActionResult> CreateBusinessGenPostingGroup(View_GenPostingGroups.GenPostingGroup dto)
        {
            if (dto.Code != "" && dto.Description != "")
            {
                var grpobj = new GenPostingGroups.CreateGenPostingGroup()
                {
                    Code = dto.Code,
                    Description = dto.Description,
                    CompanyID = Guid.Parse(_sessionManager.GetSessionObject("companyid")),
                    OrganisationID = Guid.Parse(_sessionManager.GetSessionObject("organisationid")),
                    VatID = dto.VatID
                };

                await _genPostingGroups.CreateGenBusPostingGroupsAsync(grpobj);

            }


            _sessionManager.SaveSessionObject("Gen Business Posting Groups", "page_title");

            return RedirectToAction("GenBusinessPostingGroups");
            
        }


        //[HttpPost]
        //public async Task<IActionResult> UpdateProductVatPostingGroup(View_VATPostingGroups.VATPostingGroup dto)
        //{
        //    if (!string.IsNullOrEmpty(dto.Code) && !string.IsNullOrEmpty(dto.Description))
        //    {
        //        var grpobj = new VATPostingGroups.VATPostingGroup()
        //        {
        //            Id = dto.Id,
        //            Code = dto.Code,
        //            Description = dto.Description,
        //            CompanyID = Guid.Parse(_sessionManager.GetSessionObject("companyid")),
        //            OrganisationID = Guid.Parse(_sessionManager.GetSessionObject("organisationid"))
        //        };

        //        await _vatPostingGroups.UpdateVATProdPostingGroupsAsync(grpobj);
        //    }


        //    //_sessionManager.SaveSessionObject("VAT Product Posting Groups", "page_title");

        //    return RedirectToAction("ProductVatPostingGroups");
        //}


        //[HttpPost]
        //public async Task<IActionResult> UpdateBusinessVatPostingGroup(View_VATPostingGroups.VATPostingGroup dto)
        //{
        //    if (!string.IsNullOrEmpty(dto.Code) && !string.IsNullOrEmpty(dto.Description))
        //    {
        //        var grpobj = new VATPostingGroups.VATPostingGroup()
        //        {
        //            Id = dto.Id,
        //            Code = dto.Code,
        //            Description = dto.Description,
        //            CompanyID = Guid.Parse(_sessionManager.GetSessionObject("companyid")),
        //            OrganisationID = Guid.Parse(_sessionManager.GetSessionObject("organisationid"))
        //        };

        //        await _vatPostingGroups.UpdateVATBusPostingGroupsAsync(grpobj);
        //    }

        //    //_sessionManager.SaveSessionObject("VAT Product Posting Groups", "page_title");

        //    return RedirectToAction("BusinessVatPostingGroups");
        //}

        public async Task<JsonResult> GetGenProductGroup(string id)
        {
            try
            {

                var _genprodGroup = await _genPostingGroups.GetGenProdPostingGroupAsync(_sessionManager.GetSessionObject("organisationid"), _sessionManager.GetSessionObject("companyid"), id.ToString());

                return Json(new { code = _genprodGroup.Code, name = _genprodGroup.Description, id = _genprodGroup.Id, vatID = _genprodGroup.VatID });

            }
            catch (Exception e)
            {

                var _genprodGroup = new GenPostingGroups.GenPostingGroup();
                return Json(new { code = _genprodGroup.Code, name = _genprodGroup.Description, id = _genprodGroup.Id, vatID = _genprodGroup.VatID });

            }


        }

        public async Task<JsonResult> GetGenBusinessGroup(string id)
        {
            try
            {

                var _genbusGroup = await _genPostingGroups.GetGenBusPostingGroupAsync(_sessionManager.GetSessionObject("organisationid"), _sessionManager.GetSessionObject("companyid"), id.ToString());

                return Json(new { code = _genbusGroup.Code, name = _genbusGroup.Description, id = _genbusGroup.Id, vatID = _genbusGroup.VatID });

            }
            catch (Exception e)
            {

                var _genbusGroup = new GenPostingGroups.GenPostingGroup();
                return Json(new { code = _genbusGroup.Code, name = _genbusGroup.Description, id = _genbusGroup.Id, vatID = _genbusGroup.VatID });

            }


        }

        [HttpPost]
        public async Task<IActionResult> UpdateGenProductPostingGroup(View_GenPostingGroups.GenPostingGroup dto)
        {
            if (!string.IsNullOrEmpty(dto.Code) && !string.IsNullOrEmpty(dto.Description))
            {
                var grpobj = new GenPostingGroups.GenPostingGroup()
                {
                    Id = dto.Id,
                    Code = dto.Code,
                    Description = dto.Description,
                    CompanyID = Guid.Parse(_sessionManager.GetSessionObject("companyid")),
                    OrganisationID = Guid.Parse(_sessionManager.GetSessionObject("organisationid")),
                    VatID = dto.VatID
                };

                await _genPostingGroups.UpdateGenProdPostingGroupAsync(grpobj);
            }


            //_sessionManager.SaveSessionObject("VAT Product Posting Groups", "page_title");

            return RedirectToAction("GenProductPostingGroups");
        }


        [HttpPost]
        public async Task<IActionResult> UpdateGenBusinessPostingGroup(View_GenPostingGroups.GenPostingGroup dto)
        {
            if (!string.IsNullOrEmpty(dto.Code) && !string.IsNullOrEmpty(dto.Description))
            {
                var grpobj = new GenPostingGroups.GenPostingGroup()
                {
                    Id = dto.Id,
                    Code = dto.Code,
                    Description = dto.Description,
                    CompanyID = Guid.Parse(_sessionManager.GetSessionObject("companyid")),
                    OrganisationID = Guid.Parse(_sessionManager.GetSessionObject("organisationid")),
                    VatID = dto.VatID
                };

                await _genPostingGroups.UpdateGenBusPostingGroupAsync(grpobj);
            }

            //_sessionManager.SaveSessionObject("VAT Product Posting Groups", "page_title");

            return RedirectToAction("GenBusinessPostingGroups");
        }





    }
}
