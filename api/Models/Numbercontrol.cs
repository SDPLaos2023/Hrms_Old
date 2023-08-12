using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Numbercontrol
    {
        public string Code { get; set; }
        public string Company { get; set; }
        public int? Number { get; set; }
        public string Remark { get; set; }
        public string Strlength { get; set; }

        public virtual Tbcompany CompanyNavigation { get; set; }
    }
}
