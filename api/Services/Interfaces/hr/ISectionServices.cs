using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface ISectionServices
    {
        IEnumerable<Tbsection> GetList();
        Tbsection GetSection(string id);
        string Create(Tbsection sect);
        string Update(string ID, Tbsection sect);
        string Delete(string ID);
    }
}
