using System;
using System.Collections.Generic;

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

        public virtual ICollection<Client> Clients { get; set; }
    }
}
