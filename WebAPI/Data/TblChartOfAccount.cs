using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Data
{
    public partial class TblChartOfAccount
    {
        public Guid Id { get; set; }
        public Guid OrganisationId { get; set; }
        public Guid CompanyId { get; set; }
        public int No { get; set; }
        public string Name { get; set; }
        public int IncomeBalance { get; set; }
        public int? AccountCategory { get; set; }
        public string AccountSubCategory { get; set; }
        public int DebitCredit { get; set; }
        public int AccountType { get; set; }
        public decimal? Balance { get; set; }
        public bool DirectPosting { get; set; }
        public bool Blocked { get; set; }
        public int? GenPostingType { get; set; }
        public string GenBusPostingGroup { get; set; }
        public string GenProdPostingGroup { get; set; }
        public string VatPostingGroup { get; set; }
        public string VatProdPostingGroup { get; set; }

        public virtual TblCompany Company { get; set; }
        public virtual TblOrganisation Organisation { get; set; }
    }
}
