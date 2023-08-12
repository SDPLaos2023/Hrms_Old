using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbshiftmanagement
    {
        public Tbshiftmanagement()
        {
            TbemployeeSchedules = new HashSet<TbemployeeSchedule>();
            Tbshiftdetails = new HashSet<Tbshiftdetail>();
        }

        public string Id { get; set; }
        public string Shiftname { get; set; }
        public string Workingday { get; set; }
        public string Status { get; set; }
        public string Company { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Tbcompany CompanyNavigation { get; set; }
        public virtual ICollection<TbemployeeSchedule> TbemployeeSchedules { get; set; }
        public virtual ICollection<Tbshiftdetail> Tbshiftdetails { get; set; }
    }
}
