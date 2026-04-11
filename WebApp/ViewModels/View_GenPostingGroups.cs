using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class View_GenPostingGroups
    {
        public class CreateGenPostingGroup
        {
            public Guid OrganisationID { get; set; }

            public Guid CompanyID { get; set; }

            [Display(Name = "VAT Type")]
            public Guid VatID { get; set; }

            [NotMapped]
            
            public IEnumerable<SelectListItem> VatGroups { get; set; }

            [Required]
            public string Code { get; set; }

            [Required]
            public string Description { get; set; }

            public List<GenPostingGroup> GenPostingGroups { get; set; }
        }
        public class GenPostingGroup : CreateGenPostingGroup
        {
            public Guid Id { get; set; }

            [Display(Name = "VAT Type")]
            public string VatName { get; set; }

        }
    }
}
