using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Models.auth
{
    public class UserAuthResponse
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public Tbrole Role { get; set; }
        public Tbrule Rule { get; set; }
        public Tbemployee Employee { get; set; }
        //public TbruleItem[] RuleItem { get; set; }
        //public Tbdepartment Department { get; set; }
        public bool IsChangePwd { get; set; }
    }
}
