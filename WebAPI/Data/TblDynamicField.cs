using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Data
{
    public partial class TblDynamicField
    {
        public TblDynamicField()
        {
            TblDynamicFieldValues = new HashSet<TblDynamicFieldValue>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string FieldType { get; set; }
        public bool? IsRequired { get; set; }

        public virtual ICollection<TblDynamicFieldValue> TblDynamicFieldValues { get; set; }
    }
}
