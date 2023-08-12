using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IEmployeeTypeServices
    {
        string Create(TbemployeeType emptyep);
        string Update(string id, TbemployeeType emptyep);
        string Delete(string id);
        IEnumerable<TbemployeeType> GetList();
        TbemployeeType Get(string id);
    }
}
