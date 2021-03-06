using System;
using System.Collections.Generic;

#nullable disable

namespace Recycle.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int IdGarbageCollectionPoint { get; set; }
        public int IdClient { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Text { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual GarbageCollectionPoint IdGarbageCollectionPointNavigation { get; set; }
    }
}
