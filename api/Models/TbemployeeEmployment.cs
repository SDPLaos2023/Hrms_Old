using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbemployeeEmployment
    {
        public string Id { get; set; }
        public string Employee { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Division { get; set; }
        public string Section { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Tbdepartment DepartmentNavigation { get; set; }
        public virtual Tbdivision DivisionNavigation { get; set; }
        public virtual Tbemployee EmployeeNavigation { get; set; }
        public virtual Tbpostion PositionNavigation { get; set; }
        public virtual Tbsection SectionNavigation { get; set; }
    }
}
