using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbemployeeSalarySetting
    {
        public string Id { get; set; }
        public string Employee { get; set; }
        public float? BaseSalary { get; set; }
        public string SalaryType { get; set; }
        public string SalaryPayType { get; set; }
        public string Bank { get; set; }
        public string BankAccount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Tbbank BankNavigation { get; set; }
        public virtual Tbemployee EmployeeNavigation { get; set; }
        public virtual TbsalaryPayType SalaryPayTypeNavigation { get; set; }
        public virtual TbsalaryType SalaryTypeNavigation { get; set; }
    }
}
