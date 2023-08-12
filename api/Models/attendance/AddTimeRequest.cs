using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Models.attendance
{
    public class AddTimeRequest
    {
        public TimeSpan ClockIn { get; set; }
        public TimeSpan ClockOut { get; set; }
        public DateTime AttDate { get; set; }
        public string FpUserId { get; set; }
        public string FpId { get; set; }
        public string AttCode { get; set; }
        public string  Department { get; set; }
        public string  DepartmentName { get; set; }
        public string Section { get; set; }
        public string SectionName { get; set; }
        public string Employee { get; set; }
        public string EmployeeName { get; set; }


    }
    
}
