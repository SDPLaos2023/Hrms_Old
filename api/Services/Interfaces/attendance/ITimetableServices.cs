using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.attendance
{
  public  interface ITimetableServices
    {
        string Create(Tbtimetable req);
        string Update(string id , Tbtimetable req);
        string Delete(string id);
        object GetList();

        object CreateShift(Tbshiftmanagement t);
        object UpdateShift(Tbshiftmanagement t);
        object DeleteShift(Tbshiftmanagement t);
        object GetAllShift( Inquiry t );

        object CreateShiftDetail(List<Tbshiftdetail> t);
        object UpdateShiftDetail(Tbshiftdetail t);
        object DeleteShiftDetail(Tbshiftdetail t);
        object GetAllShiftDetailList(Inquiry inq);


    }
}
