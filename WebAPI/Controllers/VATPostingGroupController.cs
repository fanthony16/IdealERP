using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.DTO;
using WebAPI.Model.Services;
using WebAPI.Model.Services.Interface;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VATPostingGroupController : ControllerBase
    {
        private readonly APIError apiError;
        private readonly ValidationErrors valErrors;
        private readonly IVATPostingGroup _vatpostinggroup;

        public VATPostingGroupController(IVATPostingGroup _vatpostinggroup, ValidationErrors valErrors, APIError apiError)
        {
            this._vatpostinggroup = _vatpostinggroup;
            this.valErrors = valErrors;
            this.apiError = apiError;

        }

        [HttpPost("business/New")]
        public async Task<IActionResult> CreateBus([FromBody] VATPostingGroups.CreateVATPostingGroup dto)
        {
            if (!ModelState.IsValid)
            {
                apiError.Detail = valErrors.getValidationErrors(ModelState);
                apiError.ErrorCode = "VatBusPostingGroup_Creation";
                return BadRequest(apiError);
            }

            var nwvatpostinggroup = await _vatpostinggroup.CreateVATBusPostingGroupsAsync(dto);
            return Ok(nwvatpostinggroup);

        }

        [HttpPost("product/New")]
        public async Task<IActionResult> CreateProd([FromBody] VATPostingGroups.CreateVATPostingGroup dto)
        {
            if (!ModelState.IsValid)
            {
                apiError.Detail = valErrors.getValidationErrors(ModelState);
                apiError.ErrorCode = "VatProdPostingGroup_Creation";
                return BadRequest(apiError);
            }

            var nwvatpostinggroup = await _vatpostinggroup.CreateVATProdPostingGroupsAsync(dto);
            return Ok(nwvatpostinggroup);

        }

        [HttpPost("product/Edit")]
        public async Task<IActionResult> UpdateProd([FromBody] VATPostingGroups.VATPostingGroup dto)
        {
            if (!ModelState.IsValid)
            {
                apiError.Detail = valErrors.getValidationErrors(ModelState);
                apiError.ErrorCode = "VatProdPostingGroup_Update";
                return BadRequest(apiError);
            }

            var vatpostinggroup = await _vatpostinggroup.UpdateVATProdPostingGroupsAsync(dto);
            return Ok(vatpostinggroup);

        }

        [HttpPost("business/Edit")]
        public async Task<IActionResult> UpdateBus([FromBody] VATPostingGroups.VATPostingGroup dto)
        {
            if (!ModelState.IsValid)
            {
                apiError.Detail = valErrors.getValidationErrors(ModelState);
                apiError.ErrorCode = "VatBusPostingGroup_Update";
                return BadRequest(apiError);
            }

            var vatpostinggroup = await _vatpostinggroup.UpdateVATBusPostingGroupsAsync(dto);
            return Ok(vatpostinggroup);

        }

        [HttpGet("business/{orgid}/{coyid}")]
        public async Task<IActionResult> GetBusinessVATGroups(string orgid, string coyid)
        {

            if (!string.IsNullOrEmpty(orgid) && !string.IsNullOrEmpty(coyid))
            {

                var businessVATgroups = await _vatpostinggroup.GetVATBusPostingGroupsAsync(orgid, coyid);
                return Ok(businessVATgroups);

            }

            return BadRequest("Organisation ID and Company ID is Required");

        }

        [HttpGet("product/{orgid}/{coyid}")]
        public async Task<IActionResult> GetProductVATGroups(string orgid, string coyid)
        {
            if (!string.IsNullOrEmpty(orgid) && !string.IsNullOrEmpty(coyid))
            {

                var productVATgroups = await _vatpostinggroup.GetVATProdPostingGroupsAsync(orgid, coyid);
                return Ok(productVATgroups);

            }

            return BadRequest("Organisation ID and Company ID is Required");
        }

        [HttpGet("business/{orgid}/{coyid}/{groupid}")]
        public async Task<IActionResult> GetBusinesVATGroup(string orgid, string coyid, string groupid)
        {

            if (!string.IsNullOrEmpty(orgid) && !string.IsNullOrEmpty(coyid) && !string.IsNullOrEmpty(groupid))
            {

                var businessVATgroup = await _vatpostinggroup.GetVATBusPostingGroupsAsync(orgid, coyid, groupid);
                return Ok(businessVATgroup);

            }

            return BadRequest("Organisation ID, Company ID and Group Code is Required");

        }

        [HttpGet("product/{orgid}/{coyid}/{groupid}")]
        public async Task<IActionResult> GetProductVATGroup(string orgid, string coyid, string groupid)
        {

            if (!string.IsNullOrEmpty(orgid) && !string.IsNullOrEmpty(coyid) && !string.IsNullOrEmpty(groupid))
            {

                var productVATgroup = await _vatpostinggroup.GetVATProdPostingGroupsAsync(orgid, coyid, groupid);
                return Ok(productVATgroup);

            }

            return BadRequest("Organisation ID, Company ID and Group Code is Required");

        }

    }
}
