using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbemployeeTransaction
    {
        public string Id { get; set; }
        public string Employee { get; set; }
        public string TransactionType { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Tbemployee EmployeeNavigation { get; set; }
        public virtual TbtransactionType TransactionTypeNavigation { get; set; }
    }
}
