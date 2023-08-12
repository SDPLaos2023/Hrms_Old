using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IEducationDegreeTypeServices
    {
        string Create(TbeducationDegree ed);
        string Update(string id, TbeducationDegree ed);
        string Delete(string id);
        IEnumerable<TbeducationDegree> GetList();
        TbeducationDegree Get(string id);
    }
}
