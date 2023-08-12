using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
  public  interface IEmployeeProbationServices
    {
        TbemployeeProbation Create(TbemployeeProbation t);
        string Update(string id, TbemployeeProbation t);
        TbemployeeProbation Get(string id);
        TbemployeeProbation GetProbation(string emp_id);
    }
}
