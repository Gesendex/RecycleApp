using System;
using System.Collections.Generic;

#nullable disable

namespace Recycle.Models
{
    public partial class GarbageCollectionPoint
    {
        public GarbageCollectionPoint()
        {
            GarbageTypeSets = new HashSet<GarbageTypeSet>();
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public int? IdCompany { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }

        public virtual Company IdCompanyNavigation { get; set; }
        public virtual ICollection<GarbageTypeSet> GarbageTypeSets { get; set; }
    }
}
