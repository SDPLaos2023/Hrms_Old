using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tborganizationchart
    {
        public string Id { get; set; }
        public string Employee { get; set; }
        public string ReportsTo { get; set; }
        public string Jobtitle { get; set; }
        public string Remark { get; set; }
    }
}
