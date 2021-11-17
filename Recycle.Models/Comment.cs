using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Recycle.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public string Text { get; set; }
        //[JsonIgnore]
        public virtual Client IdClientNavigation { get; set; }
    }
}
