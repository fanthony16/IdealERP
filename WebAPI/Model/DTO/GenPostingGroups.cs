using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model.DTO
{
    public class GenPostingGroups
    {
        public class CreateGenPostingGroup
        {
            public Guid OrganisationID { get; set; }

            public Guid CompanyID { get; set; }

            public Guid? VatID { get; set; }

            [Required]
            public string Code { get; set; }

            [Required]
            public string Description { get; set; }
        }
        public class GenPostingGroup : CreateGenPostingGroup
        {
            public Guid Id { get; set; }
        }
    }
}
