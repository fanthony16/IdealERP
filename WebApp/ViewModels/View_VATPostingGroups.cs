using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class View_VATPostingGroups
    {
        public class CreateVATPostingGroup
        {
            public Guid OrganisationID { get; set; }

            public Guid CompanyID { get; set; }

            [Required]
            public string Code { get; set; }

            [Required]
            public string Description { get; set; }

            public List<VATPostingGroup> VATPostingGroups { get; set; }
        }
        public class VATPostingGroup : CreateVATPostingGroup
        {
            public Guid Id { get; set; }
        }
    }
}
