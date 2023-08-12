using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbholidaySetting
    {
        public string Id { get; set; }
        public DateTime? Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsDraft { get; set; }
    }
}
