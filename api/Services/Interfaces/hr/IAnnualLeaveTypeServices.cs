using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IAnnualLeaveTypeServices
    {
        string Create(TbannualLeaveType t);
        string Update(string id, TbannualLeaveType t);
        string Delete(string id);
        IEnumerable<TbannualLeaveType> GetList();
        TbannualLeaveType Get(string id);
    }
}
