﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Recycle.Models
{
    public partial class Client
    {
        public Client()
        {
            Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Middlename { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int IdRole { get; set; }
        [JsonIgnore]
        public virtual Role IdRoleNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}