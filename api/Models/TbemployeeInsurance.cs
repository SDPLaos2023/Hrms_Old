using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbemployeeInsurance
    {
        public string Id { get; set; }
        public string Employee { get; set; }
        public string Ssn { get; set; }
        public float? Rate { get; set; }
        public string InsuranceCertificate { get; set; }
        public DateTime? InsuranceExpiryDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Tbemployee EmployeeNavigation { get; set; }
    }
}
