using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Recycle.Models
{
    public partial class GarbageTypeSet
    {
        public int IdGarbageCollectionPoint { get; set; }
        public int IdTypeOfGarbage { get; set; }
        [JsonIgnore]
        public virtual GarbageCollectionPoint IdGarbageCollectionPointNavigation { get; set; }
        [JsonIgnore]
        public virtual TypeOfGarbage IdTypeOfGarbageNavigation { get; set; }
    }
}
