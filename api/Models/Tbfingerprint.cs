using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbfingerprint
    {
        public Tbfingerprint()
        {
            Tbattendancelogs = new HashSet<Tbattendancelog>();
            Tbattlogs = new HashSet<Tbattlog>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public string Port { get; set; }
        public string Sn { get; set; }
        public string Mac { get; set; }
        public string Remark { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Tbattendancelog> Tbattendancelogs { get; set; }
        public virtual ICollection<Tbattlog> Tbattlogs { get; set; }
    }
}
