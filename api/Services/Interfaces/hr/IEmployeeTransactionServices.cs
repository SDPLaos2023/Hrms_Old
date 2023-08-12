using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
   public interface IEmployeeTransactionServices
    {
        TbemployeeTransaction Create(TbemployeeTransaction t);
        string Update(string id, TbemployeeTransaction t);
        string Delete(string id);
        IEnumerable<TbemployeeTransaction> GetList(string employeeId);
        TbemployeeTransaction Get(string id);
    }
}
