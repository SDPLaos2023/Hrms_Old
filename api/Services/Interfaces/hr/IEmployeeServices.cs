using hrm_api.Models;
using hrm_api.Models.hr;
using hrm_api.Models.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
   public interface IEmployeeServices
    {
        Tbemployee Create(Tbemployee t);
        string Update(string id, Tbemployee t);
        string Delete(string id);
        IEnumerable<Tbemployee> GetList();
        IEnumerable<EmployeeNoneUserResponse> GetListNoneUser();
        Tbemployee Get(string id);
        Tbemployee CreateOnce(CreateEmployeeRequest t);
        string UpdateOnce(string id, CreateEmployeeRequest t);
        object GetEmployeeName(string id);
        object GetEmployeeDepartment(string department);







    }
}
