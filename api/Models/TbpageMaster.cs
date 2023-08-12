using System;
using System.Collections.Generic;

#nullable disable

namespace hrm_api.Models
{
    public partial class TbpageMaster
    {
        public TbpageMaster()
        {
            TbruleItems = new HashSet<TbruleItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
        public string Description { get; set; }
        public string PageGroup { get; set; }

        public virtual ICollection<TbruleItem> TbruleItems { get; set; }
    }
}
