using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Data
{
    public partial class TblUserOrganization
    {
        public TblUserOrganization()
        {
            InverseOrganization = new HashSet<TblUserOrganization>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid RoleId { get; set; }
        public int Status { get; set; }
        public DateTime JoinedAt { get; set; }

        public virtual TblUserOrganization Organization { get; set; }
        public virtual TblRole Role { get; set; }
        public virtual TblUser User { get; set; }
        public virtual ICollection<TblUserOrganization> InverseOrganization { get; set; }
    }
}
