using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IEmployeeGroupServices
    {
        string Create(TbemployeeGroup t);
        string Update(string id, TbemployeeGroup t);
        string Delete(string id);
        IEnumerable<TbemployeeGroup> GetList();
        TbemployeeGroup Get(string id);
    }
}
