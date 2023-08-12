using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Models.hr
{
    [Keyless]
    public class Employee
    {
        public string employeecode { get; set; }
        public string employeename { get; set; }
        public string fp_user_id { get; set; }
        public string department { get; set; }
        public string departmentname { get; set; }
        public string division { get; set; }
        public string divisionname { get; set; }
        public string section { get; set; }
        public string sectionname { get; set; }

    }
}
