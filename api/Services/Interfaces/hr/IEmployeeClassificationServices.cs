using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IEmployeeClassificationServices
    {
        TbemployeeClassification Create(TbemployeeClassification t);
        string Update(string id, TbemployeeClassification t);
        TbemployeeClassification Get(string id);
        TbemployeeClassification GetClassification(string emp_id);
    }
}
