using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.attendance
{
    public interface IHolidaySettingServices
    {
        string Create(TbholidaySetting t);
        string Update(string id,TbholidaySetting t);
        string Delete(string id);
        IEnumerable<TbholidaySetting> GetListDraff();
        IEnumerable<TbholidaySetting> GetList(string year);
        TbholidaySetting Get(string id);
        object GetListHolidayByDate(Inquiry t);



    }
}
