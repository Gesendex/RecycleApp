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
        [JsonIgnore]
        public virtual ICollection<GarbageTypeSet> GarbageTypeSets { get; set; }
    }
}
