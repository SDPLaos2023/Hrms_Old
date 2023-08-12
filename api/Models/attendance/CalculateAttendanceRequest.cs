using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Models.attendance
{
    public class CalculateAttendanceRequest
    {
        public string ids { get; set; }
        public DateTime asofdate { get; set; }
        public string creator { get; set; }
        public string company { get; set; }
    }

    [Keyless]
    public class CalculateAttendanceResponse
    {
        public string employeecode { get; set; }
        public string employeename { get; set; }
        public int minwork { get; set; }
        public int late_in { get; set; }
        public int total_late { get; set; }
        public int early_out { get; set; }
        public int total_early_out { get; set; }
        public int totalworkdays { get; set; }
        public int totaldays { get; set; }
        public int total_hrs { get; set; }
        public double totalworkhrs { get; set; }
        public int totalmissdays { get; set; }
        public int totalleavewp { get; set; }
        public int totalleavewop { get; set; }
        public int totalleaves { get; set; }
        public string sessionid { get; set; }
        public string created_by { get; set; }
        public string data_asofdate { get; set; }
    }
}
