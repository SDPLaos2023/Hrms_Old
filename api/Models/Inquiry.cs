using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Models
{
    public class Inquiry
    {
        public string company { get; set; }
        public string employee { get; set; }
        public string id { get; set; }
        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }



    }
}
