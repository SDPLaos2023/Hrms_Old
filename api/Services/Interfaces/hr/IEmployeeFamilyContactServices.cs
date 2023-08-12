using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IEmployeeFamilyContactServices
    {
        TbemployeeFamilyContact Create(TbemployeeFamilyContact t);
        string Update(string id, TbemployeeFamilyContact t);
        TbemployeeFamilyContact Get(string id);
    }
}
