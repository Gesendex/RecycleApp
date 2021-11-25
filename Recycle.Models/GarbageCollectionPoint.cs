using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Recycle.Models
{
    public partial class GarbageCollectionPoint
    {
        public GarbageCollectionPoint()
        {
            Comments = new HashSet<Comment>();
            GarbageTypeSets = new HashSet<GarbageTypeSet>();
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public int IdCompany { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }

        public virtual Company IdCompanyNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<GarbageTypeSet> GarbageTypeSets { get; set; }
    }
}
