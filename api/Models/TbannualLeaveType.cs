using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbannualLeaveType
    {
        public TbannualLeaveType()
        {
            TbemployeeLeaveSettings = new HashSet<TbemployeeLeaveSetting>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
        public int? Ratio { get; set; }
        public string Status { get; set; }
        public string LeaveType { get; set; }
        public string Company { get; set; }

        public virtual Tbcompany CompanyNavigation { get; set; }
        public virtual ICollection<TbemployeeLeaveSetting> TbemployeeLeaveSettings { get; set; }
    }
}
