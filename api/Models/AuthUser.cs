using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class AuthUser
    {
        public AuthUser()
        {
            AuthSessions = new HashSet<AuthSession>();
            AuthUserRoles = new HashSet<AuthUserRole>();
            AuthUserRules = new HashSet<AuthUserRule>();
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Employee { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
        public string Rule { get; set; }
        public bool? IsChangePwd { get; set; }

        public virtual Tbemployee EmployeeNavigation { get; set; }
        public virtual Tbrole RoleNavigation { get; set; }
        public virtual Tbrule RuleNavigation { get; set; }
        public virtual ICollection<AuthSession> AuthSessions { get; set; }
        public virtual ICollection<AuthUserRole> AuthUserRoles { get; set; }
        public virtual ICollection<AuthUserRule> AuthUserRules { get; set; }
    }
}
