using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RecycleApp.Models
{
    public partial class CommentDtoIn
    {
        public string CorrectDate { get
            {
                const string format = "g";
                var culture = CultureInfo.CreateSpecificCulture("es-ES");
                return this.DateOfCreation.ToString(format, culture);
            }
        }
    }
}
