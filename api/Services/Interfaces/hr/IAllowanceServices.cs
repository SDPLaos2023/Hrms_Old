using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IAllowanceServices
    {
        Tballowance Create(Tballowance t);
        string Update(string id, Tballowance t);
        string Delete(string id);
        IEnumerable<Tballowance> GetList();
        Tballowance Get(string id);
    }
}
