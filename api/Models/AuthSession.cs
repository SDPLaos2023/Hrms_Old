using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class AuthSession
    {
        public string Id { get; set; }
        public string Os { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string User { get; set; }
        public string LastToken { get; set; }
        public string Location { get; set; }

        public virtual AuthUser UserNavigation { get; set; }
    }
}
