using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
   public interface IEmployeeContactServices
    {
        TbemployeeContact Create(TbemployeeContact t);
        string Update(string id, TbemployeeContact t);
        TbemployeeContact Get(string id);
    }
}
