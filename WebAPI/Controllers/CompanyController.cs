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

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {

            if (!string.IsNullOrEmpty(id))
            {

                //return Ok(await companyService.GetOrgCompanysAsync(id));

                var result = await companyService.GetOrgCompanysAsync(id);
                return Ok(result);

                //if (result.Count > 0)
                //{
                //    return Ok(result);
                //}
                //else
                //{
                //    return NotFound(id);
                //}

            }

            return BadRequest("Organisation ID is Required");

            //return Ok(new { message = "No Company found" });

        }

        [HttpPost]
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



    }
}
