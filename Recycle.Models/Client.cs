using System;
using System.Collections.Generic;

#nullable disable

namespace Recycle.Models
{
    public partial class Client
    {
        public Client()
        {
            Comments = new HashSet<Comment>();
            Companies = new HashSet<Company>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Middlename { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdRole { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
    }
}
