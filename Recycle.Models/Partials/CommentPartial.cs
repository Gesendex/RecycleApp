using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Recycle.Models
{
    public partial class Comment
    {
        [JsonIgnore]
        public string CorrectDate { get
            {
                string format = "g";
                CultureInfo culture = CultureInfo.CreateSpecificCulture("es-ES");
                return this.DateOfCreation.ToString(format, culture);
            }
        }
    }
}
