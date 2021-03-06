using System;
using System.Collections.Generic;

#nullable disable

namespace Recycle.Models
{
    public partial class GarbageTypeSet
    {
        public int IdGarbageCollectionPoint { get; set; }
        public int IdTypeOfGarbage { get; set; }

        public virtual GarbageCollectionPoint IdGarbageCollectionPointNavigation { get; set; }
        public virtual TypeOfGarbage IdTypeOfGarbageNavigation { get; set; }
    }
}
