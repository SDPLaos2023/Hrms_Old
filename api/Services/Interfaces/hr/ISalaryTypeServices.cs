using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface ISalaryTypeServices
    {
        string Create(TbsalaryType t);
        string Update(string id, TbsalaryType t);
        string Delete(string id);
        IEnumerable<TbsalaryType> GetList();
        TbsalaryType Get(string id);
    }
}
