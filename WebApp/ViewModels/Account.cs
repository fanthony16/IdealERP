using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class Account
    {
        public class Login {

            [Required]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Email Address")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name ="Password")]
            public string Password { get; set; }
            [Display(Name = "Remember Me")]
            public bool RememberMe { get; set; }


        }
        public class Register {

            [Required(ErrorMessage = "First Name is Required")]
            public string First_name { get; set; } = null;
            [Required(ErrorMessage = "Last Name is Required")]
            public string Last_name { get; set; }

            [Required(ErrorMessage ="Password is Required")]
            [DataType(DataType.Password)]

            //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#^()_+=\-])[A-Za-z\d@$!%*?&#^()_+=\-]{8,}$", ErrorMessage = "Password must be at least 8 characters long and include uppercase, lowercase, number, and special character.")]

            public string Password { get; set; }

            [Required(ErrorMessage = "Password is Required")]
            [DataType(DataType.Password)]
            [Display(Name ="Confirm Password")]
            [Compare("Password", ErrorMessage = "Password Must be Same")]
            public string Comfirm_Password { get; set; }
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required]
            public string Telephone { get; set; }

        }
    }
}
