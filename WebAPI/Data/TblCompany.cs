using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Data
{
    public partial class TblCompany
    {
        public TblCompany()
        {
            TblChartOfAccounts = new HashSet<TblChartOfAccount>();
            TblGenBusinessPostingGroups = new HashSet<TblGenBusinessPostingGroup>();
            TblGenProductPostingGroups = new HashSet<TblGenProductPostingGroup>();
            TblVatBusinessPostingGroups = new HashSet<TblVatBusinessPostingGroup>();
            TblVatProductPostingGroups = new HashSet<TblVatProductPostingGroup>();
        }

        public Guid Id { get; set; }
        public Guid OrganisationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string ContactName { get; set; }
        public string PhoneNo { get; set; }
        public string VatRegNo { get; set; }
        public string PictureUrl { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string BankName { get; set; }
        public string BankBranchNo { get; set; }
        public string BankAccountNo { get; set; }
        public string PaymentRoutingNo { get; set; }
        public string GiroNo { get; set; }
        public string SwiftCode { get; set; }
        public string Iban { get; set; }
        public string BankAccPostingGroup { get; set; }
        public string ShipToName { get; set; }
        public string ShipToAddress { get; set; }
        public string ShipToAddress2 { get; set; }
        public string ShipToCity { get; set; }
        public string ShipToCounty { get; set; }
        public string ShipToPostCode { get; set; }
        public string ShipToCountry { get; set; }
        public string ShipToContact { get; set; }
        public string ShipToLocation { get; set; }
        public bool IsDefault { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual TblOrganisation Organisation { get; set; }
        public virtual ICollection<TblChartOfAccount> TblChartOfAccounts { get; set; }
        public virtual ICollection<TblGenBusinessPostingGroup> TblGenBusinessPostingGroups { get; set; }
        public virtual ICollection<TblGenProductPostingGroup> TblGenProductPostingGroups { get; set; }
        public virtual ICollection<TblVatBusinessPostingGroup> TblVatBusinessPostingGroups { get; set; }
        public virtual ICollection<TblVatProductPostingGroup> TblVatProductPostingGroups { get; set; }
    }
}
