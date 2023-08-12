using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IInstitutionServices
    {
        string Create(Tbinstitution t);
        string Update(string id, Tbinstitution t);
        string Delete(string id);
        IEnumerable<Tbinstitution> GetList();
        Tbinstitution Get(string id);
    }
}
