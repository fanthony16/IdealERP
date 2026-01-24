using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Data
{
    public partial class TblAuditLog
    {
        public Guid Id { get; set; }
        public Guid ActorUserId { get; set; }
        public Guid OrganizationId { get; set; }
        public string Action { get; set; }
        public string EntityType { get; set; }
        public int EntityId { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual TblUser ActorUser { get; set; }
        public virtual TblOrganisation Organization { get; set; }
    }
}
