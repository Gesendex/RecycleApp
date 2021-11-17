﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Recycle.Models
{
    public partial class Role
    {
        public Role()
        {
            Clients = new HashSet<Client>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }
        //[JsonIgnore]
        public virtual ICollection<Client> Clients { get; set; }
    }
}
