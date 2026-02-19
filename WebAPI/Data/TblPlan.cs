using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Data
{
    public partial class TblPlan
    {
        public TblPlan()
        {
            TblSubscriptions = new HashSet<TblSubscription>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int MaxUsers { get; set; }
        public string ModulesEnabled { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }

        public virtual TblCurrency CurrencyNavigation { get; set; }
        public virtual ICollection<TblSubscription> TblSubscriptions { get; set; }
    }
}
