using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model.DTO
{
    public class User
    {
        public class UserList {

            public Guid UserID { get; set; }
            
            public string FirstName  { get; set; }

            public string LastName { get; set; }

            public string PhoneNumber { get; set; }

            public string Email { get; set; }

            public string Status { get; set; }

        }

        public class RegisterUser {

            [Required]
            [StringLength(50,MinimumLength = 2, ErrorMessage = "First Name Must be between 2 and 50 character length")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(50, MinimumLength = 2, ErrorMessage = "Last Name Must be between 2 and 50 character length")]
            public string LastName { get; set; }

            [Required]
            [StringLength(30, MinimumLength = 2, ErrorMessage = "Phone Number Must be between 2 and 30 character length")]
            public string PhoneNumber { get; set; }

            [Required]
            [DataType(DataType.EmailAddress, ErrorMessage = "Provide Valid Email Address")]
            
            public string Email { get; set; }           


            [Required]
            [RegularExpression(@"^(?=(?:.*[A-Z]){2,})(?=(?:.*[^a-zA-Z0-9]){2,}).+$", ErrorMessage = "Password must contain at least 2 uppercase letters and 2 special characters.")]
            public string Password { get; set; }

            
        }

        public class UpdateUser {

            [Required]
            [StringLength(50, MinimumLength = 2, ErrorMessage = "First Name Must be between 2 and 50 character length")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(50, MinimumLength = 2, ErrorMessage = "Last Name Must be between 2 and 50 character length")]
            public string LastName { get; set; }

            [Required]
            [StringLength(30, MinimumLength = 2, ErrorMessage = "Phone Number Must be between 2 and 30 character length")]
            public string PhoneNumber { get; set; }

            [Required]
            [DataType(DataType.EmailAddress, ErrorMessage = "Provide Valid Email Address")]

            public string Email { get; set; }

            [Required]
            [DataType(DataType.EmailAddress, ErrorMessage = "Provide Valid Email Address")]
            public string ComfirmEmail { get; set; }

            [Required]
            public string Status { get; set; }

        }

        public class ValidateUser
        {

            [Required]
            [DataType(DataType.EmailAddress, ErrorMessage = "Provide Valid Email Address")]
            public string Email { get; set; }


            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

        }



    }
}
