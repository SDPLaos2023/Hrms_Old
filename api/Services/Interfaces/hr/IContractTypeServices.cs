using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IContractTypeServices
    {
        string Create(TbcontractType wt);
        string Update(string id, TbcontractType wt);
        string Delete(string id);
        IEnumerable<TbcontractType> GetList();
        TbcontractType Get(string id);
    }
}
