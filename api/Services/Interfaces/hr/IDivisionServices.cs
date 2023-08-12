using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IDivisionServices
    {
        IEnumerable<Tbdivision> GetList();
        Tbdivision GetDivision(string ID);
        string Create(Tbdivision div);
        string Delete(string id);
        string Update(string ID, Tbdivision div);



    }
}
