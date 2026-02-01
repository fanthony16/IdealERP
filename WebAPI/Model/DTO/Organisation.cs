using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model.DTO
{
    public class Organisation
    {
        public class CreateOrganisation
        {

            [Required]
            public string Legal_name { get; set; }
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Business_Email { get; set; }
            [Required]
            public string Industry { get; set; }
            [Required]
            public string CountryName { get; set; }
            [Required]
            public string CurrencyType { get; set; }
            [Required]
            public bool AcceptTerms { get; set; }

        }

        public class UpdateOrganisation : CreateOrganisation
        {

            public Guid Id { get; set; }

        }

        public class Organisations : CreateOrganisation
        {

            public Guid Id { get; set; }
           
        }
    }
}
