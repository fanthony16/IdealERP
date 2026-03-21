using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class View_ChartLedgerAccount
    {
        public class CreateLedgerAccount
        {
            
            public Guid OrganisationID { get; set; }
            
            public Guid CompanyID { get; set; }
            [Required]
            [Display(Name = "No")]
            public int AccountNo { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            [Display(Name = "Income/Balance")]
            public string IncomeBalance { get; set; }
            
            [Display(Name = "Account Category")]
            public int AccountCategory { get; set; }
            [Display(Name = "Account Sub Category")]
            public string AccountSubCategory { get; set; }
            [Required]
            [Display(Name = "Debit/Credit")]
            public int DebitCredit { get; set; }
            [Required]
            [Display(Name = "Account Type")]
            public string AccountType { get; set; }
            public decimal? Balance { get; set; } = 0;
            [Required]
            [Display(Name = "Direct Posting")]
            public bool DirectPosting { get; set; }
            [Required]
            public bool Blocked { get; set; }
            
            [Display(Name = "Gen. Posting Type")]
            public int GeneralPostingType { get; set; }

            [Display(Name ="Gen. Bus. Posting Group")]
            public string GeneralBusinessPostingGroup { get; set; }

            [Display(Name = "Gen. Prod. Posting Group")]
            public string GeneralProductPostingGroup { get; set; }

            [Display(Name = "Vat. Bus. Posting Group")]
            public string VatBusinessPostingGroup { get; set; }

            [Display(Name = "Vat. Prod. Posting Group")]
            public string VatProductPostingGroup { get; set; }

            
        }

        public class UpdateLedgerAccount : CreateLedgerAccount
        {
            [Required]
            public Guid LedgerID { get; set; }

        }

        public class LedgerAccount : CreateLedgerAccount
        {
            [Required]
            public Guid LedgerID { get; set; }

        }

    }
}
