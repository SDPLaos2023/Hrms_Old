using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.auth
{
    public interface IUserServices
    {
        object Create(AuthUser t);
        object Update(string id, AuthUser t);
        object ChangePassword(string id, AuthUser t);
        object GetList();
        object Get(string id);
        object Delete(string id);
    }
}
