using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrintLoggingService
{
    class Fp
    {
        public string id { get; set; }
        public string name { get; set; }
        public string ipAddress { get; set; }
        public string port { get; set; }
        public string sn { get; set; }
        public string mac { get; set; }
        public object remark { get; set; }
        public string status { get; set; }
    }

    public partial class Attlog
    {
        public string FpId { get; set; }
        public DateTime AttDate { get; set; }
        public TimeSpan AttTime { get; set; }
        public string AttCode { get; set; }
        public string FpUserId { get; set; }
    }



}
