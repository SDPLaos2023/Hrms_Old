using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbnationality
    {
        public Tbnationality()
        {
            Tbemployees = new HashSet<Tbemployee>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Tbemployee> Tbemployees { get; set; }
    }
}
