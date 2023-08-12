using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.attendance
{
   public interface IDeviceManagerServices
    {
        string Create(Tbfingerprint t);
        string Update(string id, Tbfingerprint t);
        string Delete(string id);
        IEnumerable<Tbfingerprint> GetList();
        Tbfingerprint Get(string id);
    }
}
