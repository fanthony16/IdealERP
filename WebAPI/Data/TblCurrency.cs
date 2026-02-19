using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Data
{
    public partial class TblCurrency
    {
        public TblCurrency()
        {
            TblOrganisations = new HashSet<TblOrganisation>();
            TblPlans = new HashSet<TblPlan>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TblOrganisation> TblOrganisations { get; set; }
        public virtual ICollection<TblPlan> TblPlans { get; set; }
    }
}
