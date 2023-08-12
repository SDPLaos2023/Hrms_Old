using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IDepartmentServices
    {
        IEnumerable<Tbdepartment> GetList();
        Tbdepartment GetDepartment(string ID);
        string Create(Tbdepartment dept);
        string Update(string ID, Tbdepartment dept);
        string Delete(string ID);
    }
}
