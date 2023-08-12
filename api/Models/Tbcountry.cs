using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbcountry
    {
        public Tbcountry()
        {
            Tbemployees = new HashSet<Tbemployee>();
            Tbprovinces = new HashSet<Tbprovince>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Tbemployee> Tbemployees { get; set; }
        public virtual ICollection<Tbprovince> Tbprovinces { get; set; }
    }
}
