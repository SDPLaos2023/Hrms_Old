using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbemployeeContact
    {
        public string Id { get; set; }
        public string Employee { get; set; }
        public string Mobile { get; set; }
        public string Home { get; set; }
        public string Email { get; set; }
        public string Wa { get; set; }
        public string Line { get; set; }
        public string Wechat { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Skype { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public string ContactRelation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Tbemployee EmployeeNavigation { get; set; }
    }
}
