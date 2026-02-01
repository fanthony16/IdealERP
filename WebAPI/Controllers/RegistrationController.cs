using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Model.Services;
using static WebAPI.Model.DTO.Organisation;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        
        private readonly IOrganisationsvr registrationService;
        public RegistrationController(IOrganisationsvr registrationService)
        {
            
            this.registrationService = registrationService;
        }
        [HttpPost("CreateOrganisation")]
        public async Task<IActionResult> CreateOrg([FromBody] CreateOrganisation dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdOrganisation = await registrationService.CreateOrganisationAsync(dto);
            if (createdOrganisation is null)
            {
                return NotFound(new { message = $"Organisation Creation Failed" });
            }

            return Ok(createdOrganisation);

        }
        [HttpGet("GetAllOrganisation")]
        public async Task<ActionResult<List<Organisations>>> GetAllOrg()
        {
            var _users = await registrationService.GetAllOrganisationAsync();
            return Ok(_users);
        }

    }
}
