using hrm_api.Models;
using hrm_api.Models.attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static hrm_api.Models.dbContext;

namespace hrm_api.Services.Interfaces.attendance
{
    public interface ITimesheetService
    {
        IEnumerable<Tbtimesheet> GetPersonTimesheet(TimesheetInq req);
        object GetAttendanceByDepartment(TimesheetInq req);
        object UploadAttendanceLog(List<Tbattlog> req);
        object Tests();
        object RecalculateData(List<FpRecalculateRequest> t);

        object GetTimesheetByDate(TimesheetInq t);
        object GetAllTimesheetMonthly(TimesheetInq t);

        object AddTime(List<AddTimeRequest> t);
        object GetTimesheetByFpUser(AddTimeRequest t);
        object GetUserTimesheetByDate(TimesheetInq t);
        object UpdateTimesheet(List<Timesheet> t);
        object AddLog(List<AddTimeRequest> t);
        object CalculateAttendance(CalculateAttendanceRequest t);
        object GetWorkingPeriodList(string company);
        object NewWorkingPeriod(Tbworkingperiod t);
        object UpdateWorkingPeriod(Tbworkingperiod t);
        object ActiveWorkingPeriod(string wkpid);
        object GetUserWorkingPeriod(string fpuserid);
        object GetEmployeeTimeAssignment(string employee);




    }
}
