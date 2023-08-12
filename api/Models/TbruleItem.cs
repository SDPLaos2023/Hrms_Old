using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbruleItem
    {
        public string Id { get; set; }
        public string Rule { get; set; }
        public string PageName { get; set; }
        public string Uri { get; set; }
        public int? PageId { get; set; }
        public int? Seq { get; set; }

        public virtual TbpageMaster Page { get; set; }
        public virtual Tbrule RuleNavigation { get; set; }
    }
}
