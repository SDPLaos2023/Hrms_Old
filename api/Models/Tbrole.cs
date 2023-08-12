﻿using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbrole
    {
        public Tbrole()
        {
            AuthUserRoles = new HashSet<AuthUserRole>();
            AuthUsers = new HashSet<AuthUser>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }

        public virtual ICollection<AuthUserRole> AuthUserRoles { get; set; }
        public virtual ICollection<AuthUser> AuthUsers { get; set; }
    }
}
