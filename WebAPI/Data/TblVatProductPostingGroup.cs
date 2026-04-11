using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Data
{
    public partial class TblVatProductPostingGroup
    {
        public Guid Id { get; set; }
        public Guid OrganisationId { get; set; }
        public Guid CompanyId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual TblCompany Company { get; set; }
        public virtual TblOrganisation Organisation { get; set; }
    }
}
