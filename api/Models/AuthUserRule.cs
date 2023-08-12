using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class AuthUserRule
    {
        public string Id { get; set; }
        public string User { get; set; }
        public string Rule { get; set; }

        public virtual Tbrule RuleNavigation { get; set; }
        public virtual AuthUser UserNavigation { get; set; }
    }
}
