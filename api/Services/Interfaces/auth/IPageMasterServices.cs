using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.auth
{
    public interface IPageMasterServices
    {
        object GetList();
        object GetList(string group);
    }
}
