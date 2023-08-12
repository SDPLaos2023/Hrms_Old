using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class AuthUserRole
    {
        public string Id { get; set; }
        public string User { get; set; }
        public string Role { get; set; }

        public virtual Tbrole RoleNavigation { get; set; }
        public virtual AuthUser UserNavigation { get; set; }
    }
}
