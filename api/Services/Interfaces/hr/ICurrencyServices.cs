using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface ICurrencyServices
    {
        string Create(Tbcurrency wt);
        string Update(string id, Tbcurrency wt);
        string Delete(string id);
        IEnumerable<Tbcurrency> GetList();
        Tbcurrency Get(string id);
    }
}
