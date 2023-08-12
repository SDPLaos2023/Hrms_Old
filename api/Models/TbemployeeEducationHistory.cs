using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbemployeeEducationHistory
    {
        public string Id { get; set; }
        public string Employee { get; set; }
        public string Institution { get; set; }
        public string Degree { get; set; }
        public short? Year { get; set; }
        public string Major { get; set; }
        public string Gpa { get; set; }
        public int? Sequence { get; set; }

        public virtual TbeducationDegree DegreeNavigation { get; set; }
        public virtual Tbemployee EmployeeNavigation { get; set; }
        public virtual Tbinstitution InstitutionNavigation { get; set; }
    }
}
