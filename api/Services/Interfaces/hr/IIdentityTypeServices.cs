using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
   public interface IIdentityTypeServices
    {
        TbidentityType Create(TbidentityType t);
        string Update(string id, TbidentityType t);
        string Delete(string id);
        IEnumerable<TbidentityType> GetList();
        TbidentityType Get(string id);
    }
}
