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
            TblCompanies = new HashSet<TblCompany>();
            TblUserOrganizations = new HashSet<TblUserOrganization>();
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
        public virtual ICollection<TblCompany> TblCompanies { get; set; }
        public virtual ICollection<TblUserOrganization> TblUserOrganizations { get; set; }
    }
}
