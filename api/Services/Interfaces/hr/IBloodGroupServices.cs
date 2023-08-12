using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IBloodGroupServices
    {
        string Create(Tbbloodgroup tbbloodgroup);
        string Update(string id, Tbbloodgroup tbbloodgroup);
        string Delete(string id);
        IEnumerable<Tbbloodgroup> GetList();
        Tbbloodgroup Get(string id);
    }
}
