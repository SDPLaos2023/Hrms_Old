using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Models.attendance
{
    public class TimesheetInq
    {
        public string employee { get; set; }
        public string department { get; set; }
        public DateTime datefrom { get; set; }
        public DateTime dateto { get; set; }
    }
    
}
