using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Data
{
    public partial class TblOrganisation
    {
        public TblOrganisation()
        {
            TblAuditLogs = new HashSet<TblAuditLog>();
            TblChartOfAccounts = new HashSet<TblChartOfAccount>();
            TblCompanies = new HashSet<TblCompany>();
            TblGenBusinessPostingGroups = new HashSet<TblGenBusinessPostingGroup>();
            TblGenProductPostingGroups = new HashSet<TblGenProductPostingGroup>();
            TblUserOrganizations = new HashSet<TblUserOrganization>();
            TblVatBusinessPostingGroups = new HashSet<TblVatBusinessPostingGroup>();
            TblVatProductPostingGroups = new HashSet<TblVatProductPostingGroup>();
        }

        public Guid Id { get; set; }
        public string LegalName { get; set; }
        public string TradeName { get; set; }
        public string Industry { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public string Timezone { get; set; }
        public int? CompanySize { get; set; }
        public int RegistrationStage { get; set; }
        public DateTime CreatedAt { get; set; }
        public string BusinessEmail { get; set; }
        public bool AcceptTerms { get; set; }

        public virtual TblCountry CountryNavigation { get; set; }
        public virtual TblCurrency CurrencyNavigation { get; set; }
        public virtual ICollection<TblAuditLog> TblAuditLogs { get; set; }
        public virtual ICollection<TblChartOfAccount> TblChartOfAccounts { get; set; }
        public virtual ICollection<TblCompany> TblCompanies { get; set; }
        public virtual ICollection<TblGenBusinessPostingGroup> TblGenBusinessPostingGroups { get; set; }
        public virtual ICollection<TblGenProductPostingGroup> TblGenProductPostingGroups { get; set; }
        public virtual ICollection<TblUserOrganization> TblUserOrganizations { get; set; }
        public virtual ICollection<TblVatBusinessPostingGroup> TblVatBusinessPostingGroups { get; set; }
        public virtual ICollection<TblVatProductPostingGroup> TblVatProductPostingGroups { get; set; }
    }
}
