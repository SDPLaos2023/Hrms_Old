using hrm_api.Models;
using hrm_api.Models.hr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface ICompanyService
    {
        IEnumerable<Tbcompany> GetList();
        Tbcompany GetCompany(string ID);
        string Create(Tbcompany company);
        string Update(string ID, Tbcompany company);
    }
}
