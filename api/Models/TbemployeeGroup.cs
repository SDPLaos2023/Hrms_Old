using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbemployeeGroup
    {
        public TbemployeeGroup()
        {
            TbemployeeClassifications = new HashSet<TbemployeeClassification>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }

        public virtual ICollection<TbemployeeClassification> TbemployeeClassifications { get; set; }
    }
}
