using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Recycle.Models
{
    public partial class TypeOfGarbage
    {
        public TypeOfGarbage()
        {
            GarbageTypeSets = new HashSet<GarbageTypeSet>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public virtual TypeImage TypeImage { get; set; }
        public virtual ICollection<GarbageTypeSet> GarbageTypeSets { get; set; }
    }
}
