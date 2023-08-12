using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbemployeeIdentity
    {
        public string Id { get; set; }
        public string IdNumber { get; set; }
        public string IdType { get; set; }
        public DateTime? IdExpiryDate { get; set; }
        public string IdIssuedBy { get; set; }
        public string Employee { get; set; }

        public virtual Tbemployee EmployeeNavigation { get; set; }
        public virtual TbidentityType IdTypeNavigation { get; set; }
    }
}
