using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.attendance
{
    public interface IDeviceUserFingerMappingServices
    {
        string Create(Tbfingerprintmapping t);
        string Update(string id, Tbfingerprintmapping t);
        string Delete(string id);
        Tbfingerprintmapping Get(string id);
        IEnumerable<Tbfingerprintmapping> GetList(string id);
    }
}
