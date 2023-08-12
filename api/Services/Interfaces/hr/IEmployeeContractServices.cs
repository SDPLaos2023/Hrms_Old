using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IEmployeeContractServices
    {
        TbemployeeContract Create(TbemployeeContract t);
        string Update(string id, TbemployeeContract t);
        TbemployeeContract Get(string id);
        TbemployeeContract GetContract(string emp_id);
    }
}
