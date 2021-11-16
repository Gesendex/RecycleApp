using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Recycle.Models
{
    public partial class Company
    {
        public Company()
        {
            GarbageCollectionPoints = new HashSet<GarbageCollectionPoint>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public virtual ICollection<GarbageCollectionPoint> GarbageCollectionPoints { get; set; }
    }
}
