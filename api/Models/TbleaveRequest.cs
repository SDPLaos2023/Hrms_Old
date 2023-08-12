using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbleaveRequest
    {
        public string Id { get; set; }
        public string Employee { get; set; }
        public string LeaveType { get; set; }
        public DateTime? Datefrom { get; set; }
        public DateTime? Dateto { get; set; }
        public float? Total { get; set; }
        public bool? NeedApproval { get; set; }
        public bool? NeedHrApproval { get; set; }
        public string ApprovedBy { get; set; }
        public string HrApprovedBy { get; set; }
        public string ApprovalNote { get; set; }
        public string HrApprovalNote { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string Remark { get; set; }
        public string FpUserId { get; set; }
        public string Company { get; set; }
        public string Status { get; set; }

        public virtual Tbcompany CompanyNavigation { get; set; }
        public virtual Tbemployee EmployeeNavigation { get; set; }
    }
}
