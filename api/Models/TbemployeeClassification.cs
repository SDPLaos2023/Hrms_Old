using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbemployeeClassification
    {
        public string Id { get; set; }
        public string Employee { get; set; }
        public string EmployeeType { get; set; }
        public string EmployeeGroup { get; set; }
        public string EmployeeCategory { get; set; }
        public string EmployeeLevel { get; set; }
        public string EmployeeWorkingType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual TbemployeeCatagory EmployeeCategoryNavigation { get; set; }
        public virtual TbemployeeGroup EmployeeGroupNavigation { get; set; }
        public virtual TbemployeeLevel EmployeeLevelNavigation { get; set; }
        public virtual Tbemployee EmployeeNavigation { get; set; }
        public virtual TbemployeeType EmployeeTypeNavigation { get; set; }
        public virtual TbworkingType EmployeeWorkingTypeNavigation { get; set; }
    }
}
