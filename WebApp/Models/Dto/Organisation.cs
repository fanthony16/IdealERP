using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.Dto
{
   

    public class Organisation
    {

        public class Organisations : CreateOrganisation
        {

            public Guid Id { get; set; }


        }

        public class UpdateOrganisation : CreateOrganisation
        {

            public Guid Id { get; set; }

        }

        public class CreateOrganisation
        {
            public string Legal_name { get; set; }

            public string Business_Email { get; set; }

            public string Industry { get; set; }

            public string CountryName { get; set; }

            public string CurrencyType { get; set; }

            public bool AcceptTerms { get; set; }
        }

        public class AssignOganisationOwnerUser
        {

            public Guid OrganisationID { get; set; }
            
            public Guid UserID { get; set; }
        }

    }
}
