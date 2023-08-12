using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class Tbfpuser
    {
        public string Id { get; set; }
        public string FpId { get; set; }
        public string FpUserName { get; set; }
        public string FpUserId { get; set; }
        public string FpRole { get; set; }
        public string Employee { get; set; }
    }
}
