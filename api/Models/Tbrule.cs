using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbrule
    {
        public Tbrule()
        {
            AuthUserRules = new HashSet<AuthUserRule>();
            AuthUsers = new HashSet<AuthUser>();
            TbruleItems = new HashSet<TbruleItem>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public virtual ICollection<AuthUserRule> AuthUserRules { get; set; }
        public virtual ICollection<AuthUser> AuthUsers { get; set; }
        public virtual ICollection<TbruleItem> TbruleItems { get; set; }
    }
}
