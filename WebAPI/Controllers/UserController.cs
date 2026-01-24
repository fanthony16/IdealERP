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

            var created = await userService.RegisterUserAsyn(dto);
            if (!created)
            {
                return NotFound(new { message = $"User Registration Failed" });
            }

            return Ok("User Registration Succesful");
        }

        [HttpPost("ValidateUser")]
        public async Task<IActionResult> ValidateUser([FromBody] ValidateUser dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isValidUser = await userService.ValidateUserAsyn(dto);
            if (!isValidUser)
            {
                return NotFound(new { message = $"Invalid Username or Password" });
            }

            return Ok("Account Validated Succesful");
        }


        [HttpGet("GetAllUser")]
        public async Task<ActionResult<List<UserList>>> GetAllUser() 
        {
            var _users = await userService.GetAllUsersAsync();
            return Ok(_users);
        }




    }
    
}

