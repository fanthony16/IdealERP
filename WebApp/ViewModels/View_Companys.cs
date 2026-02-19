using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class View_Companys
    {
        public class CreateCompany
        {

            public Guid OrganisationId { get; set; }

            public string Name { get; set; }
            public string Address { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string County { get; set; }
            [Display(Name = "Post Code")]
            public string PostCode { get; set; }
            public string Country { get; set; }
            [Display(Name = "Contact Name")]
            public string ContactName { get; set; }

            [Display(Name = "Phone No")]
            public string PhoneNo { get; set; }
            [Display(Name = "VAT Reg No")]
            public string VatRegNo { get; set; }
            [Display(Name = "Picture")]
            public string PictureUrl { get; set; }

            [Display(Name = "Fax No")]
            public string FaxNo { get; set; }

            public string Email { get; set; }
            public string Website { get; set; }
            public string BankName { get; set; }
            [Display(Name = "Bank Branch No")]
            public string BankBranchNo { get; set; }
            [Display(Name = "Bank Account No")]
            public string BankAccountNo { get; set; }
            [Display(Name = "Payment Routing No")]
            public string PaymentRoutingNo { get; set; }
            public string GiroNo { get; set; }
            public string SwiftCode { get; set; }
            public string Iban { get; set; }
            [Display(Name ="Bank Posting Group")]
            public string BankAccountPostingGroup { get; set; }
            [Display(Name = "Ship To Name")]
            public string ShipToName { get; set; }
            [Display(Name = "Ship To Address")]
            public string ShipToAddress { get; set; }
            [Display(Name = "Ship To Address 2")]
            public string ShipToAddress2 { get; set; }
            [Display(Name = "Ship To City")]
            public string ShipToCity { get; set; }
            [Display(Name = "Ship To County")]
            public string ShipToCounty { get; set; }
            [Display(Name = "Ship To Post Code")]
            public string ShipToPostCode { get; set; }
            [Display(Name = "Ship To Country")]
            public string ShipToCountry { get; set; }
            [Display(Name = "Ship To Contact")]
            public string ShipToContact { get; set; }
            [Display(Name = "Ship To Location")]
            public string ShipToLocation { get; set; }

        }

        public class UpdateCompany : CreateCompany
        {
            public Guid CompanyID { get; set; }

        }
    }
}
