using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbemployeeLevel
    {
        public TbemployeeLevel()
        {
            TbemployeeClassifications = new HashSet<TbemployeeClassification>();
            Tbpostions = new HashSet<Tbpostion>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }
        public int? Seq { get; set; }
        public string DirectReport { get; set; }

        public virtual ICollection<TbemployeeClassification> TbemployeeClassifications { get; set; }
        public virtual ICollection<Tbpostion> Tbpostions { get; set; }
    }
}
