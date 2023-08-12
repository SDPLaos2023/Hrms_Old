using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbdivision
    {
        public Tbdivision()
        {
            TbemployeeEmployments = new HashSet<TbemployeeEmployment>();
        }

        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string Status { get; set; }
        public string Company { get; set; }

        public virtual Tbcompany CompanyNavigation { get; set; }
        public virtual ICollection<TbemployeeEmployment> TbemployeeEmployments { get; set; }
    }
}
