using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Models.attendance
{
    public class Workingperiod
    {
        public string id { get; set; }
        public string company { get; set; }
        public string name { get; set; }
        public string started_at { get; set; }
        public string ended_at { get; set; }
        public string total { get; set; }
        public string working_hrs { get; set; }
        public string created_at { get; set; }
        public string created_by { get; set; }
        public string updated_at { get; set; }
        public string updated_by { get; set; }
        public string status { get; set; }

    }
}
