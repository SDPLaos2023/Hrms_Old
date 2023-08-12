using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbdevice
    {
        public string Id { get; set; }
        public string Sn { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }
        public bool? Status { get; set; }
        public string Remark { get; set; }
        public string Homebranch { get; set; }
    }
}
