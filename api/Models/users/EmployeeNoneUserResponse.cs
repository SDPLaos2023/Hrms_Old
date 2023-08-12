using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Models.users
{
    public class EmployeeNoneUserResponse
    {
        public string id { get; set; }
        public string employee_name { get; set; }
        public string department_name { get; set; }
        public string division_name { get; set; }
    }
}
