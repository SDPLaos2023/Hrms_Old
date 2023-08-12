using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hrm_api.Models;
namespace hrm_api.Services.Interfaces.hr
{
    public interface IEmployeeIdentityServices
    {
        IEnumerable<TbemployeeIdentity> GetList(string employeeId);
        IEnumerable<TbemployeeIdentity> CreateOnce(string employeeId, TbemployeeIdentity[] identities);
        object Create(TbemployeeIdentity identity);
        object Get(string id);
        string Update(string id, TbemployeeIdentity identity);
        string Delete(string id);


    }
}
