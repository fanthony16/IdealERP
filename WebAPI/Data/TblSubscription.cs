using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Data
{
    public partial class TblSubscription
    {
        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid PlanId { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string BillingCycle { get; set; }

        public virtual TblPlan Plan { get; set; }
    }
}
