using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface ICountryServices
    {
        string Create(Tbcountry country);
        string Update(string id, Tbcountry country);
        string Delete(string id);
        IEnumerable<Tbcountry> GetList();
        Tbcountry Get(string id);
    }
}
