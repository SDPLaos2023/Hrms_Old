using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IEmployeeLevelServices
    {
        string Create(TbemployeeLevel t);
        string Update(string id, TbemployeeLevel t);
        string Delete(string id);
        IEnumerable<TbemployeeLevel> GetList();
        TbemployeeLevel Get(string id);
    }
}
