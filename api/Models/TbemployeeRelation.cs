using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbemployeeRelation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string Relation { get; set; }
        public DateTime? Dob { get; set; }
        public string Status { get; set; }

        public virtual Tbrelation RelationNavigation { get; set; }
    }
}
