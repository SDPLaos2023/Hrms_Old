using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbcontoller
    {
        public Tbcontoller()
        {
            Tbcompanies = new HashSet<Tbcompany>();
        }

        public string Code { get; set; }
        public string ControllerName { get; set; }
        public string Status { get; set; }
        public string Keys { get; set; }

        public virtual ICollection<Tbcompany> Tbcompanies { get; set; }
    }
}
