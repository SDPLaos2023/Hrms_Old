using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IProvinceServices
    {
        string Create(Tbprovince t);
        string Update(string id, Tbprovince t);
        string Delete(string id);
        IEnumerable<Tbprovince> GetList();
        Tbprovince Get(string id);
    }
}
