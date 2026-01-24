using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Data
{
    public partial class TblRole
    {
        public TblRole()
        {
            TblUserOrganizations = new HashSet<TblUserOrganization>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Scope { get; set; }

        public virtual ICollection<TblUserOrganization> TblUserOrganizations { get; set; }
    }
}
