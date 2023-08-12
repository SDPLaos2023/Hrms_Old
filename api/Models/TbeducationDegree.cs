using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbeducationDegree
    {
        public TbeducationDegree()
        {
            TbemployeeEducationHistories = new HashSet<TbemployeeEducationHistory>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }

        public virtual ICollection<TbemployeeEducationHistory> TbemployeeEducationHistories { get; set; }
    }
}
