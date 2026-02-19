using Microsoft.AspNetCore.Authorization;
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
    //[Authorize(Roles ="Admin")]
    public class UserController : ControllerBase
    {
        
        private readonly IUser userService;
        private readonly ValidationErrors valErrors;
        private readonly APIError apiError;

        public UserController(IUser userService, ValidationErrors valErrors, APIError apiError)
        {
            this.valErrors = valErrors;
            this.apiError = apiError;
            this.userService = userService;
        }
        
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUser dto)
        {

            if (!ModelState.IsValid)
            {
                apiError.Detail = valErrors.getValidationErrors(ModelState);
                apiError.Message = "Account_Creation";
                return BadRequest(apiError);

            }

            var createdUser = await userService.RegisterUserAsyn(dto);

            if (createdUser.Email == "")
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

                apiError.Detail = valErrors.getValidationErrors(ModelState);
                apiError.Message = "Account_Validation";

                return BadRequest(ModelState);

            }

            var ValidatedUser = await userService.ValidateUserAsyn(dto);

            if (ValidatedUser != null)
            {
                return Ok(ValidatedUser);
                
            }

            return NotFound(new { message = $"Invalid Username or Password" });

        }


        [HttpGet("Users")]
        public async Task<ActionResult<List<UserList>>> GetAllUser([FromQuery] char AccountType) 
        {
            var _users = await userService.GetAllUsersAsync(AccountType);

            if (_users != null)
            {
                return NotFound(new { message = $"Users Not Found" });
            }
            return Ok(_users);

        }




    }
    
}

