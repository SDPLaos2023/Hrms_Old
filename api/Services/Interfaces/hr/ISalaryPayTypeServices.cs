using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface ISalaryPayTypeServices
    {
        string Create(TbsalaryPayType t);
        string Update(string id, TbsalaryPayType t);
        string Delete(string id);
        IEnumerable<TbsalaryPayType> GetList();
        TbsalaryPayType Get(string id);
    }
}
