using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IEmployeeEmploymentServices
    {
        TbemployeeEmployment Create(TbemployeeEmployment t);
        string Update(string id, TbemployeeEmployment t);
        TbemployeeEmployment Get(string id);
        TbemployeeEmployment GetEmployment(string emp_id);
    }
}
