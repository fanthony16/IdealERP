using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Data
{
    public partial class TblContract
    {
        public TblContract()
        {
            TblDynamicFieldValues = new HashSet<TblDynamicFieldValue>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TblDynamicFieldValue> TblDynamicFieldValues { get; set; }
    }
}
