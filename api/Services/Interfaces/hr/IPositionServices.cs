using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IPositionServices
    {
        IEnumerable<Tbpostion> GetList();
        Tbpostion GetPosition(string id);
        string Create(Tbpostion posi);
        string Update(string ID, Tbpostion posi);
        string Delete(string ID);
    }
}
