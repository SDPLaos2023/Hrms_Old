using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.auth
{
    public interface IRoleServices
    {
        object Get(string id);
        object GetList();
        //object Create(Tbrule t);
        //object Update(string id, Tbrule t);
        //object Delete(string id);
    }
}
