using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IEmployeeHealthHistoryServices
    {
        TbemployeeHealthHistory Create(TbemployeeHealthHistory t);
        string Update(string id, TbemployeeHealthHistory t);
        string Delete(string id);
        IEnumerable<TbemployeeHealthHistory> GetList(string emp_id);
        TbemployeeHealthHistory Get(string id);
    }
}
