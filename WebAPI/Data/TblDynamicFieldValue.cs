using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Data
{
    public partial class TblDynamicFieldValue
    {
        public int Id { get; set; }
        public int? EntityId { get; set; }
        public int? DynamicFieldId { get; set; }
        public string Value { get; set; }

        public virtual TblDynamicField DynamicField { get; set; }
        public virtual TblContract Entity { get; set; }
    }
}
