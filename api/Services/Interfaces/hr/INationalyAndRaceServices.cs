using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface INationalyAndRaceServices
    {
        string CreateNationality(Tbnationality nationality);
        string CreateRace(Tbrace race);
        string UpdateRace(string id, Tbrace race);
        string UpdateNationality(string id, Tbnationality nationality);
        string DeleteNationality(string id);
        string DeleteRace(string id);
        IEnumerable<Tbnationality> GetListNationalities();
        IEnumerable<Tbrace> GetListRaces();
        Tbnationality GetNationalitie(string id);
        Tbrace GetRace(string id);
    }
}
