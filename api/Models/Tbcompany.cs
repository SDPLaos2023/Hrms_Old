using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbcompany
    {
        public Tbcompany()
        {
            InverseHomebranchNavigation = new HashSet<Tbcompany>();
            Numbercontrols = new HashSet<Numbercontrol>();
            TbannualLeaveTypes = new HashSet<TbannualLeaveType>();
            Tbattcalculateds = new HashSet<Tbattcalculated>();
            Tbdepartments = new HashSet<Tbdepartment>();
            Tbdivisions = new HashSet<Tbdivision>();
            Tbemployees = new HashSet<Tbemployee>();
            TbleaveRequests = new HashSet<TbleaveRequest>();
            Tbshiftmanagements = new HashSet<Tbshiftmanagement>();
            Tbtimetables = new HashSet<Tbtimetable>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
        public string Homebranch { get; set; }
        public string Controller { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }

        public virtual Tbcontoller ControllerNavigation { get; set; }
        public virtual Tbcompany HomebranchNavigation { get; set; }
        public virtual ICollection<Tbcompany> InverseHomebranchNavigation { get; set; }
        public virtual ICollection<Numbercontrol> Numbercontrols { get; set; }
        public virtual ICollection<TbannualLeaveType> TbannualLeaveTypes { get; set; }
        public virtual ICollection<Tbattcalculated> Tbattcalculateds { get; set; }
        public virtual ICollection<Tbdepartment> Tbdepartments { get; set; }
        public virtual ICollection<Tbdivision> Tbdivisions { get; set; }
        public virtual ICollection<Tbemployee> Tbemployees { get; set; }
        public virtual ICollection<TbleaveRequest> TbleaveRequests { get; set; }
        public virtual ICollection<Tbshiftmanagement> Tbshiftmanagements { get; set; }
        public virtual ICollection<Tbtimetable> Tbtimetables { get; set; }
    }
}
