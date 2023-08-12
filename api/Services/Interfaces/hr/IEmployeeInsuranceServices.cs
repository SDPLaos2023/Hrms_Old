using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
   public interface IEmployeeInsuranceServices
    {
        TbemployeeInsurance Create(TbemployeeInsurance t);
        string Update(string id, TbemployeeInsurance t);
        TbemployeeInsurance Get(string id);
        TbemployeeInsurance GetInsurance(string emp_id);
    }
}
