using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
    public interface IEmployeeLeaveSettingServices
    {
        TbemployeeLeaveSetting Create(TbemployeeLeaveSetting t);
        string Update(string id, TbemployeeLeaveSetting t);
        TbemployeeLeaveSetting Get(string id);
        TbemployeeLeaveSetting GetLeaveSetting(string emp_id);

        object GetEmployeeLeaveRequest(Inquiry i);
        object CreateLeaveRequest(TbleaveRequest t);
        object UpdateLeaveRequest(TbleaveRequest t); // supervisor and hr approve or change status
        object DeleteLeaveRequest(TbleaveRequest t);
        object GetLeaveRequest(Inquiry i);
        object GetLeaveEmployeeHistory(Inquiry i);
        object GetEmployeeLeaveRequestNeedApproval(Inquiry t);
        object GetEmployeeLeaveRequestApproved(Inquiry t);
        object GetEmployeeLeaveRequestRejected(Inquiry t);
        object GetEmployeeLeaveRequestHrNeedApproval(Inquiry t);
        object GetEmployeeLeaveRequestHrApproved(Inquiry t);
        object GetEmployeeLeaveRequestHrRejected(Inquiry t);
        object GetEmployeeLeaveRemain(Inquiry t);
        object GetEmployeeLeaveCount(Inquiry t);
        object GetEmployeeLeaveSummary(Inquiry t);



    }
}
