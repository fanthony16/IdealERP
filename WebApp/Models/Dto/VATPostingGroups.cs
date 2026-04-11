using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.Dto
{
    public class VATPostingGroups
    {
        public class CreateVATPostingGroup
        {
            public Guid OrganisationID { get; set; }

            public Guid CompanyID { get; set; }

            
            public string Code { get; set; }

            
            public string Description { get; set; }
        }
        public class VATPostingGroup : CreateVATPostingGroup
        {
            public Guid Id { get; set; }
        }
    }
}
