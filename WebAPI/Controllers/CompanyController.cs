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
    public class CompanyController : ControllerBase
    {
        private readonly ICompany companyService;
        private readonly ValidationErrors valErrors;
        private readonly APIError apiError;

        public CompanyController(ICompany companyService, ValidationErrors valErrors, APIError apiError)
        {
            this.companyService = companyService;
            this.valErrors = valErrors;
            this.apiError = apiError;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {

            if (!string.IsNullOrEmpty(id))
            {

                var result = await companyService.GetOrgCompanysAsync(id);
                return Ok(result);

            }

            return BadRequest("Organisation ID is Required");

        }

        [HttpGet("Find")]
        public async Task<IActionResult> GetCompany(string id, string coyid)
        {

            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(coyid))
            {

                var result = await companyService.GetCompanyAsync(id,coyid);
                return Ok(result);

            }

            return BadRequest("Organisation ID and Company ID is Required");

        }

        [HttpPost("New")]
        public async Task<IActionResult> Create([FromBody] Companys.CreateCompany dto)
        {

            if (!ModelState.IsValid)
            {
                apiError.Detail = valErrors.getValidationErrors(ModelState);
                apiError.ErrorCode = "Company_Creation";

                return BadRequest(apiError);

            }

            var dbCompany = await companyService.CreateCompanyAsync(dto);

            if (dbCompany is null)
            {
                return NotFound(new { message = $"Company Creation Failed" });
            }

            return Ok(dbCompany);

        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] Companys.UpdateCompany dto)
        {

            if (!ModelState.IsValid)
            {
                //apiError.Detail = valErrors.getValidationErrors(ModelState);
                //apiError.ErrorCode = "Update_Creation";
                
                return BadRequest(ModelState);

            }

            var dbCompany = await companyService.UpdateCompanyAsync(dto);

            if (dbCompany is null)
            {
                return NotFound(new { message = $"Company Creation Failed" });
            }

            return Ok(dbCompany);

        }



    }
}
