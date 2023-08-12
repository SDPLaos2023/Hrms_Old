using hrm_api.Models;
using hrm_api.Models.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.attendance
{
   public interface IDeviceUsersServices
    {
        string Create(Tbfpuser t);
        string Update(string id,Tbfpuser t);
        string Delete(string id);
        Tbfpuser Get(string id);
        string TransferUser(string newFpId,Tbfpuser t);
        IEnumerable<Tbfpuser> GetList(string id);
        IEnumerable<EmployeeNoneUserResponse> GetListNoneUser(string fpId);
        object GetFpUserId(string employee);
    }
}
