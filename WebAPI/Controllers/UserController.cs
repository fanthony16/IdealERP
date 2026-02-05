using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Model.Services;
using static WebAPI.Model.DTO.User;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IdealERPContext dbContext;
        private readonly IUser userService;

        public UserController(IdealERPContext dbContext, IUser userService)
        {
            this.dbContext = dbContext;
            this.userService = userService;
        }
        
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUser dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdUser = await userService.RegisterUserAsyn(dto);
            if (createdUser is null)
            {
                return NotFound(new { message = $"User Registration Failed" });
            }

            return Ok(createdUser);

        }

        


        [HttpPost("ValidateUser")]
        public async Task<IActionResult> ValidateUser([FromBody] ValidateUser dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ValidatedUser = await userService.ValidateUserAsyn(dto);
            if (ValidatedUser is null)
            {
                return NotFound(new { message = $"Invalid Username or Password" });
            }

            return Ok(ValidatedUser);
        }


        [HttpGet("Users")]
        public async Task<ActionResult<List<UserList>>> GetAllUser([FromQuery] char AccountType) 
        {
            var _users = await userService.GetAllUsersAsync(AccountType);
            return Ok(_users);
        }




    }
    
}

