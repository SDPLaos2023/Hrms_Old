using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbsalaryType
    {
        public TbsalaryType()
        {
            TbemployeeSalarySettings = new HashSet<TbemployeeSalarySetting>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }

        public virtual ICollection<TbemployeeSalarySetting> TbemployeeSalarySettings { get; set; }
    }
}
