using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tballowance
    {
        public Tballowance()
        {
            InverseGroupNavigation = new HashSet<Tballowance>();
            TbemployeeAllowances = new HashSet<TbemployeeAllowance>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }
        public string Group { get; set; }

        public virtual Tballowance GroupNavigation { get; set; }
        public virtual ICollection<Tballowance> InverseGroupNavigation { get; set; }
        public virtual ICollection<TbemployeeAllowance> TbemployeeAllowances { get; set; }
    }
}
