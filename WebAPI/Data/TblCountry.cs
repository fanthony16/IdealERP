using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Data
{
    public partial class TblCountry
    {
        public TblCountry()
        {
            TblOrganisations = new HashSet<TblOrganisation>();
        }

        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<TblOrganisation> TblOrganisations { get; set; }
    }
}
