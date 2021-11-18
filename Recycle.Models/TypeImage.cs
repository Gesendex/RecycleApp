using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Recycle.Models
{
    public partial class TypeImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        [JsonIgnore]
        public virtual TypeOfGarbage IdNavigation { get; set; }
    }
}
