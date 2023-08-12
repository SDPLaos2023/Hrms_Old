using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
   public interface IEmployeeEduHistoryServices
    {
        IEnumerable<TbemployeeEducationHistory> GetList(string employeeId);
        IEnumerable<TbemployeeEducationHistory> CreateOnce(string employeeId, TbemployeeEducationHistory[] identities);
        TbemployeeEducationHistory Create(TbemployeeEducationHistory identity);
        TbemployeeEducationHistory Get(string id);
        string Update(string id, TbemployeeEducationHistory identity);
        string Delete(string id);
    }
}
