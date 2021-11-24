using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Recycle.Models
{
    
    public partial class Client
    {
        [JsonIgnore]
        public string FullName
        {
            get { return this.Name + " " + this.Surname + " " + this.Middlename; }
        }

    }
}
