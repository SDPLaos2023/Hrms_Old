using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbemployeeProbation
    {
        public string Id { get; set; }
        public string Employee { get; set; }
        public DateTime? ContractStartAt { get; set; }
        public DateTime? ContractStopAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Tbemployee EmployeeNavigation { get; set; }
    }
}
