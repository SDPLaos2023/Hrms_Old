using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IEmployeeCategoryServices
    {
        string Create(TbemployeeCatagory t);
        string Update(string id, TbemployeeCatagory t);
        string Delete(string id);
        IEnumerable<TbemployeeCatagory> GetList();
        TbemployeeCatagory Get(string id);
    }
}
