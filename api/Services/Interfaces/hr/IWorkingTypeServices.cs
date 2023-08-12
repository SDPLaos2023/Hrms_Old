using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IWorkingTypeServices
    {
        string Create(TbworkingType wt);
        string Update(string id, TbworkingType wt);
        string Delete(string id);
        IEnumerable<TbworkingType> GetList();
        TbworkingType Get(string id);
    }
}
