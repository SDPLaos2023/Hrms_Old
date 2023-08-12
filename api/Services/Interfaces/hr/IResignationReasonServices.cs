using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IResignationReasonServices
    {
        string Create(Tbresignationreason wt);
        string Update(string id, Tbresignationreason wt);
        string Delete(string id);
        IEnumerable<Tbresignationreason> GetList();
        Tbresignationreason Get(string id);
    }
}
