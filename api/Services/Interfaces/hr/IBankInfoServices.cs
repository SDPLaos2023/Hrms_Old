using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IBankInfoServices
    {
        string Create(Tbbank t);
        string Update(string id, Tbbank t);
        string Delete(string id);
        IEnumerable<Tbbank> GetList();
        Tbbank Get(string id);
    }
}
