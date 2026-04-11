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
    public class GenPostingGroupController : ControllerBase
    {

        private readonly APIError apiError;
        private readonly ValidationErrors valErrors;
        private readonly IGenPostingGroups _genpostinggroup;

        public GenPostingGroupController(IGenPostingGroups _genpostinggroup, ValidationErrors valErrors, APIError apiError)
        {
            this._genpostinggroup = _genpostinggroup;
            this.valErrors = valErrors;
            this.apiError = apiError;
        }

        [HttpPost("business/New")]
        public async Task<IActionResult> CreateBus([FromBody] GenPostingGroups.CreateGenPostingGroup dto)
        {
            if (!ModelState.IsValid)
            {
                apiError.Detail = valErrors.getValidationErrors(ModelState);
                apiError.ErrorCode = "GenBusPostingGroup_Creation";
                return BadRequest(apiError);
            }

            var nwgetpostinggroup = await _genpostinggroup.CreateGenBusPostingGroupsAsync(dto);
            return Ok(nwgetpostinggroup);

        }

        [HttpPost("product/New")]
        public async Task<IActionResult> CreateProd([FromBody] GenPostingGroups.CreateGenPostingGroup dto)
        {
            if (!ModelState.IsValid)
            {
                apiError.Detail = valErrors.getValidationErrors(ModelState);
                apiError.ErrorCode = "GenProdPostingGroup_Creation";
                return BadRequest(apiError);
            }

            var nwvatpostinggroup = await _genpostinggroup.CreateGenProdPostingGroupsAsync(dto);
            return Ok(nwvatpostinggroup);

        }

        [HttpPost("product/Edit")]
        public async Task<IActionResult> UpdateProd([FromBody] GenPostingGroups.GenPostingGroup dto)
        {
            if (!ModelState.IsValid)
            {
                apiError.Detail = valErrors.getValidationErrors(ModelState);
                apiError.ErrorCode = "GenProdPostingGroup_Update";
                return BadRequest(apiError);
            }

            var vatpostinggroup = await _genpostinggroup.UpdateGenProdPostingGroupsAsync(dto);
            return Ok(vatpostinggroup);

        }

        [HttpPost("business/Edit")]
        public async Task<IActionResult> UpdateBus([FromBody] GenPostingGroups.GenPostingGroup dto)
        {
            if (!ModelState.IsValid)
            {
                apiError.Detail = valErrors.getValidationErrors(ModelState);
                apiError.ErrorCode = "VatBusPostingGroup_Update";
                return BadRequest(apiError);
            }

            var genpostinggroup = await _genpostinggroup.UpdateGenBusPostingGroupsAsync(dto);
            return Ok(genpostinggroup);

        }

        [HttpGet("business/{orgid}/{coyid}")]
        public async Task<IActionResult> GetBusinessGenGroups(string orgid, string coyid)
        {

            if (!string.IsNullOrEmpty(orgid) && !string.IsNullOrEmpty(coyid))
            {

                var businessGengroups = await _genpostinggroup.GetGenBusPostingGroupsAsync(orgid, coyid);
                return Ok(businessGengroups);

            }

            return BadRequest("Organisation ID and Company ID is Required");

        }

        [HttpGet("product/{orgid}/{coyid}")]
        public async Task<IActionResult> GetProductGenGroups(string orgid, string coyid)
        {
            if (!string.IsNullOrEmpty(orgid) && !string.IsNullOrEmpty(coyid))
            {

                var productGengroups = await _genpostinggroup.GetGenProdPostingGroupsAsync(orgid, coyid);
                return Ok(productGengroups);

            }

            return BadRequest("Organisation ID and Company ID is Required");

        }

        [HttpGet("business/{orgid}/{coyid}/{groupid}")]
        public async Task<IActionResult> GetBusinesGenGroup(string orgid, string coyid, string groupid)
        {

            if (!string.IsNullOrEmpty(orgid) && !string.IsNullOrEmpty(coyid) && !string.IsNullOrEmpty(groupid))
            {

                var businessGengroup = await _genpostinggroup.GetGenBusPostingGroupsAsync(orgid, coyid, groupid);
                return Ok(businessGengroup);

            }

            return BadRequest("Organisation ID, Company ID and Group Code is Required");

        }

        [HttpGet("product/{orgid}/{coyid}/{groupid}")]
        public async Task<IActionResult> GetProductGenGroup(string orgid, string coyid, string groupid)
        {

            if (!string.IsNullOrEmpty(orgid) && !string.IsNullOrEmpty(coyid) && !string.IsNullOrEmpty(groupid))
            {

                var productGengroup = await _genpostinggroup.GetGenProdPostingGroupsAsync(orgid, coyid, groupid);
                return Ok(productGengroup);

            }

            return BadRequest("Organisation ID, Company ID and Group Code is Required");

        }

    }
}
