using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model.Services;

namespace WebAPI.Model.DTO
{
    public class ChartLedgerAccount
    {
        public class CreateLedgerAccount
        {
            [Required]
            public Guid OrganisationID { get; set; }
            [Required]
            public Guid CompanyID { get; set; }
            [Required]
            public int AccountNo { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public int IncomeBalance { get; set; }
            [Required]
            public int? AccountCategory { get; set; }
            public string AccountSubCategory { get; set; }
            [Required]
            public int DebitCredit { get; set; }
            [Required]
            public int AccountType { get; set; }
            public decimal? Balance { get; set; }
            [Required]
            public bool DirectPosting { get; set; }
            [Required]
            public bool Blocked { get; set; }
            [Required]
            public int? GeneralPostingType { get; set; }

            public string GeneralBusinessPostingGroup { get; set; }

            public string GeneralProductPostingGroup { get; set; }

            public string VatPostingGroup { get; set; }

            public string VatProductPostingGroup { get; set; }

            public APIError Err { get; set; }
        }
        public class UpdateLedgerAccount : CreateLedgerAccount
        {
            [Required]
            public Guid LedgerID { get; set; }

        }

        public class LedgerAccount : CreateLedgerAccount
        {
            public Guid LedgerID { get; set; }

        }

    }
}
