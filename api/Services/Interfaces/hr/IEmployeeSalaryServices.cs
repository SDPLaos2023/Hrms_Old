using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IEmployeeSalaryServices
    {
        TbemployeeSalarySetting Create(TbemployeeSalarySetting t);
        string Update(string id, TbemployeeSalarySetting t);
        TbemployeeSalarySetting Get(string id);
        TbemployeeSalarySetting GetSalarySetting(string emp_id);
    }
}
