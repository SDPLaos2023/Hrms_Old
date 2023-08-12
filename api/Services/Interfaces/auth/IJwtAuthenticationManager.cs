using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.auth
{
    public interface IJwtAuthenticationManager
    {
        Task<string> Authenticate(string username, string password);
    }
}
