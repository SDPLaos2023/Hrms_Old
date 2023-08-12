using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IEmployeeAllowanceServices
    {
        IEnumerable<TbemployeeAllowance> GetList(string employeeId);
        IEnumerable<TbemployeeAllowance> CreateOnce(string employeeId, TbemployeeAllowance[] allowances);
        TbemployeeAllowance Create(TbemployeeAllowance allowance);
        TbemployeeAllowance Get(string id);
        string Update(string id, TbemployeeAllowance allowance);
        string Delete(string id);
    }
}
