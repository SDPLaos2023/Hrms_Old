using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IDistrictServices
    {
        string Create(Tbdistrict t);
        string Update(string id, Tbdistrict t);
        string Delete(string id);
        IEnumerable<Tbdistrict> GetList();
        IEnumerable<Tbdistrict> GetList(string id);
        Tbdistrict Get(string id);
    }
}
