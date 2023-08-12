using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbemployeeFamilyContact
    {
        public string Id { get; set; }
        public string Employee { get; set; }
        public string FatherName { get; set; }
        public DateTime? FatherDob { get; set; }
        public string FatherContactNumber { get; set; }
        public string MotherName { get; set; }
        public DateTime? MotherDob { get; set; }
        public string MotherContactNumber { get; set; }
        public string SpouseName { get; set; }
        public DateTime? SpouseDob { get; set; }
        public string SpouseContactNumber { get; set; }
        public int? NoChildren { get; set; }
        public int? NoDaughter { get; set; }

        public virtual Tbemployee EmployeeNavigation { get; set; }
    }
}
