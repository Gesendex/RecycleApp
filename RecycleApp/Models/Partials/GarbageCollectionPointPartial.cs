using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RecycleApp.Models
{
    public partial class GarbageCollectionPointDtoIn
    {
        [JsonIgnore]
        public string FullAddress => this.Street + " " + this.Building;
    }
}
