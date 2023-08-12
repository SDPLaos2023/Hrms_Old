using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Models.auth
{
    public class LoginRequest
    {

        public string username { get; set; }
        public string password { get; set; }
        public string browser_id { get; set; }

    }

    public class StringLoginRequest {
        public string strRequest { get; set; }
    }
}
