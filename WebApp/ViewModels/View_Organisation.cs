using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.Dto;

namespace WebApp.ViewModels
{
    public class View_Organisation
    {
        public class OrganisationObj
        {
            public Guid Id { get; set; }
            [Required]
            [Display(Name = "Organisation Name")]
            public string Legal_name { get; set; }
            [Display(Name = "Trade Name")]
            public string Trade_name { get; set; }
            [Required]
            [Display(Name = "Business Name")]
            public string Business_email { get; set; }

            [Required]
            public string Industry { get; set; }
            [Required]
            public string Country { get; set; }
            [Required]
            public string Currency { get; set; }
            public string Timezone { get; set; }
            [Display(Name = "Company Size")]
            public int Companysize { get; set; }
            [Display(Name = "Registration Stage")]
            public string Registration_stage { get; set; }

            public bool AcceptTerms { get; set; }

            public List<User.ValidUser> AllUserAccounts { get; set; }

            public List<User.ValidUser> AllUnAssignedAccounts { get; set; }

            public List<OrganisationObj> Orgs { get; set; }

            [NotMapped]
            public IEnumerable<SelectListItem> Countries { get; set; }

            [NotMapped]
            public IEnumerable<SelectListItem> Currencies { get; set; }

        }
      

        public class Create_Organisation
        {

            [Required(ErrorMessage = "Email is required")]
            [Display(Name = "Organisation Name")]
            public string Legal_name { get; set; }

            [Required(ErrorMessage = "Email is required")]
            [Display(Name = "Business Email")]
            public string Business_email { get; set; }

            [Required(ErrorMessage = "Industry is required")]
            public string Industry { get; set; }
            [Required(ErrorMessage = "Country is required")]
            public string Country { get; set; }
            [Required(ErrorMessage = "Currency is required")]
            public string Currency { get; set; }

            [Required(ErrorMessage = "Accept terms and condition")]

            public bool AcceptTerms { get; set; }

            [NotMapped]
            public IEnumerable<SelectListItem> Countries { get; set; }

            [NotMapped]
            public IEnumerable<SelectListItem> Currencies { get; set; }

        }

        public class UpdateOrganisation : Create_Organisation
        {
            [Required(ErrorMessage = "*")]
            public Guid Id { get; set; }
        }


        
    }
}
