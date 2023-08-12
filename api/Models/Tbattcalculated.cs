using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbattcalculated
    {
        public string Id { get; set; }
        public string Employeecode { get; set; }
        public string Employeename { get; set; }
        public int? Minwork { get; set; }
        public int? LateIn { get; set; }
        public int? TotalLate { get; set; }
        public int? EarlyOut { get; set; }
        public int? TotalEarlyOut { get; set; }
        public int? Totalworkdays { get; set; }
        public int? Totaldays { get; set; }
        public int? TotalHrs { get; set; }
        public double? Totalworkhrs { get; set; }
        public int? Totalmissdays { get; set; }
        public int? Totalleavewp { get; set; }
        public int? Totalleavewop { get; set; }
        public int? Totalleaves { get; set; }
        public string Sessionid { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DataAsofdate { get; set; }
        public string Company { get; set; }

        public virtual Tbcompany CompanyNavigation { get; set; }
    }
}
