using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
   public interface IMaritalStatusServices
    {
        string Create(Tbmarriage marriage);
        string Update(string id, Tbmarriage marriage);
        string Delete(string id);
        IEnumerable<Tbmarriage> GetList();
        Tbmarriage Get(string id);
    }
}
