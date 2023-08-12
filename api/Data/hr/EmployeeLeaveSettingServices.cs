using hrm_api.Models;
using hrm_api.Services.Interfaces.hr;
using log4net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Data.hr
{
    public class EmployeeLeaveSettingServices : IEmployeeLeaveSettingServices
    {
        public EmployeeLeaveSettingServices(IConfiguration configuration)
        {

            this.Configuration = configuration;
        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(EmployeeLeaveSettingServices));

        public IConfiguration Configuration { get; }

        public TbemployeeLeaveSetting Create(TbemployeeLeaveSetting t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    //string ID = NumberConstrol.GetNextNumber("ELS");

                    var rawmaxid = db.TbemployeeLeaveSettings.Max(m => m.Id);
                    var maxid = int.Parse(rawmaxid.Replace('E', ' ').Replace('L', ' ').Replace('S', ' '));
                    string id = NumberConstrol.GetNextNumber("ELS");
                    var numid = int.Parse(id.Replace('E', ' ').Replace('L', ' ').Replace('S', ' '));
                    if (numid <= maxid)
                    {
                        id = NumberConstrol.SetNewMaxNumber("ELS", maxid);
                    }

                    var d = new TbemployeeLeaveSetting();
                    d.Id = id;
                    d.Employee = t.Employee;
                    d.EmployeeAnnualLeave = t.EmployeeAnnualLeave;
                    d.Ratio = t.Ratio;
                    d.Remain = t.Remain;
                    db.TbemployeeLeaveSettings.Add(d);
                    db.SaveChanges();
                    db.Dispose();
                    return this.Get(id);
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return null;
            }
        }

        public TbemployeeLeaveSetting Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeLeaveSettings where c.Id == id select c).FirstOrDefault();
                    db.Dispose();
                    return d;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return null;
            }
        }

        public TbemployeeLeaveSetting GetLeaveSetting(string emp_id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeLeaveSettings where c.Employee == emp_id select c).FirstOrDefault();
                    db.Dispose();
                    return d;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return null;
            }
        }

        public string Update(string id, TbemployeeLeaveSetting t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeLeaveSettings where c.Id == id select c).FirstOrDefault();
                    if (d == null) throw new Exception("DATA_NOT_FOUND");
                    d.EmployeeAnnualLeave = t.EmployeeAnnualLeave;
                    d.Ratio = t.Ratio;
                    d.Remain = t.Remain;
                    db.SaveChanges();
                    db.Dispose();
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "DATA_NOT_FOUND")
                {
                    this.Create(t);
                }
                this._logger.Error(ex.Message);
                return "UNSUCCESS";
            }
        }

        public object GetEmployeeLeaveRequest(Inquiry i)
        {
            try
            {
                using (var db = new dbContext())
                {
                    var sp = db.SpEmployeeGetLeaveRequest.FromSqlRaw("CALL SpEmployeeGetLeaveRequest({0},{1})",
                       i.employee, i.company).ToList();
                    db.Dispose();
                    return sp;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error("UpdateTimesheet " + ex.Message);
                return new List<LeaveHistory>();
            }
        }

        public object CreateLeaveRequest(TbleaveRequest t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var datefrom = (DateTime)t.Datefrom;
                    var dateto = (DateTime)t.Dateto;
                    var hs = (from c in db.TbholidaySettings where c.IsDraft == false && c.Date >= datefrom.Date && c.Date <= dateto.Date select (DateTime)c.Date).ToList<DateTime>();
                    var dateleave = Enumerable.Range(0, 1 + dateto.Subtract(datefrom).Days)
                      .Select(offset => datefrom.AddDays(offset))
                      .Where(d => d.ToString("ddd") != "Sun")
                      .ToArray();

                    var allLeave = dateleave.Except(hs);
                    t.Total = allLeave.Count();

                    var fpuser = (from c in db.Tbfpusers where c.Employee == t.Employee select c.FpUserId).FirstOrDefault();
                    t.FpUserId = fpuser;

                    string id = NumberConstrol.GetNextNumber("LR");
                    var d = new TbleaveRequest
                    {
                        Id = id,
                        Employee = t.Employee,
                        LeaveType = t.LeaveType,
                        Datefrom = t.Datefrom,
                        Dateto = t.Dateto,
                        Total = t.Total,
                        NeedApproval = t.NeedApproval,
                        NeedHrApproval = t.NeedHrApproval,
                        ApprovedBy = t.ApprovedBy,
                        HrApprovedBy = t.HrApprovedBy,
                        ApprovalNote = t.ApprovalNote,
                        HrApprovalNote = t.HrApprovalNote,
                        CreatedAt = DateTime.Now,
                        CreatedBy = t.CreatedBy,
                        UpdatedAt = DateTime.Now,
                        UpdatedBy = t.UpdatedBy,
                        Remark = t.Remark,
                        FpUserId = t.FpUserId,
                        Company = t.Company,
                        Status = t.Status
                    };
                    db.TbleaveRequests.Add(d);

                    var lt = (from l in db.TbannualLeaveTypes where l.Id == t.LeaveType select l).FirstOrDefault();
                    var logs = new List<Tbleavelog>();
                    foreach (var item in allLeave)
                    {
                        var ls = "LL";
                        if (lt != null)
                        {
                            ls = lt.LeaveType;
                        }
                        string ll = NumberConstrol.GetNextNumber("LR");
                        var log = new Tbleavelog
                        {
                            Id = ll,
                            LeaveDay = item,
                            LeaveId = id,
                            FpUserId = t.FpUserId,
                            Remark = t.Remark,
                            Status = ls
                        };
                        logs.Add(log);
                    }

                    db.Tbleavelogs.AddRange(logs);
                    db.SaveChanges();
                    db.Dispose();
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return "UNSUCCESS";
            }
        }

        public object UpdateLeaveRequest(TbleaveRequest t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbleaveRequests where c.Id == t.Id select c).FirstOrDefault();
                    d.Employee = t.Employee;
                    d.LeaveType = t.LeaveType;
                    d.Datefrom = t.Datefrom;
                    d.Dateto = t.Dateto;
                    d.Total = t.Total;
                    d.NeedApproval = t.NeedApproval;
                    d.NeedHrApproval = t.NeedHrApproval;
                    d.ApprovedBy = t.ApprovedBy;
                    d.HrApprovedBy = t.HrApprovedBy;
                    d.ApprovalNote = t.ApprovalNote;
                    d.HrApprovalNote = t.HrApprovalNote;
                    d.UpdatedAt = DateTime.Now;
                    d.UpdatedBy = t.UpdatedBy;
                    d.Remark = t.Remark;
                    d.FpUserId = t.FpUserId;
                    d.Company = t.Company;
                    d.Status = t.Status;
                    db.SaveChanges();


                    if (t.Status == "SUCCESS")
                    {
                        var ls = (from s in db.TbemployeeLeaveSettings where s.Id == t.LeaveType && s.Employee == t.Employee select s).FirstOrDefault();
                        if (ls != null)
                        {
                            ls.Remain = ls.Remain - (int)d.Total;
                            db.SaveChanges();
                        }
                    }

                    db.Dispose();
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return "UNSUCCESS";
            }
        }

        public object DeleteLeaveRequest(TbleaveRequest t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbleaveRequests where c.Id == t.Id select c).FirstOrDefault();
                    d.UpdatedAt = DateTime.Now;
                    d.UpdatedBy = t.UpdatedBy;
                    d.Status = "DELETED";
                    db.SaveChanges();
                    db.Dispose();
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return "UNSUCCESS";
            }
        }

        public object GetLeaveRequest(Inquiry i)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbleaveRequests where c.Id == i.id select c).FirstOrDefault();
                    return d;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error("GetLeaveHistory " + ex.Message);
            }
            return null;

        }

        public object GetLeaveEmployeeHistory(Inquiry i)
        {
            try
            {
                using (var db = new dbContext())
                {
                    var sp = db.SpEmployeeGetLeaveHistories.FromSqlRaw("CALL SpEmployeeGetLeaveHistories({0},{1})",
                       i.employee, i.company).ToList();
                    db.Dispose();
                    return sp;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error("GetLeaveEmployeeHistory " + ex.Message);
                return new List<LeaveHistory>();
            }
        }

        public object GetEmployeeLeaveRequestNeedApproval(Inquiry t)
        {
            try
            {
                using (var hr = new hrm_projectContext())
                {
                    var sp = new List<LeaveHistory>();
                    var epm = (from c in hr.TbemployeeEmployments where c.Employee == t.employee select c).FirstOrDefault();
                    var elvl = (from c in hr.TbemployeeClassifications where c.Employee == t.employee select c).FirstOrDefault();
                    var lvl = (from c in hr.TbemployeeLevels where c.Id == elvl.EmployeeLevel select c).FirstOrDefault();


                    if (epm != null)
                    {
                        using (var db = new dbContext())
                        {
                            sp = db.SpSupervisorGetEmployeeLeaveRequest.FromSqlRaw("CALL SpSupervisorGetEmployeeLeaveRequest({0},{1},{2},{3},{4},{5})",
                              t.company,
                              epm.Department,
                              epm.Division,
                              epm.Section,
                              elvl.EmployeeLevel,
                              lvl.Seq
                              ).ToList();
                            db.Dispose();
                        }
                    }
                    return sp;
                }

            }
            catch (Exception ex)
            {
                this._logger.Error("GetEmployeeLeaveRequestNeedApproval " + ex.Message);
                return new List<LeaveHistory>();
            }
        }

        public object GetEmployeeLeaveRequestApproved(Inquiry t)
        {
            try
            {
                using (var hr = new hrm_projectContext())
                {
                    var sp = new List<LeaveHistory>();
                    var epm = (from c in hr.TbemployeeEmployments where c.Employee == t.employee select c).FirstOrDefault();
                    var elvl = (from c in hr.TbemployeeClassifications where c.Employee == t.employee select c).FirstOrDefault();
                    var lvl = (from c in hr.TbemployeeLevels where c.Id == elvl.EmployeeLevel select c).FirstOrDefault();


                    if (epm != null)
                    {
                        using (var db = new dbContext())
                        {
                            sp = db.SpSupervisorGetEmployeeLeaveRequestApproved.FromSqlRaw("CALL SpSupervisorGetEmployeeLeaveRequestApproved({0},{1},{2},{3},{4},{5},{6})",
                              t.company,
                              epm.Department,
                              epm.Division,
                              epm.Section,
                              elvl.EmployeeLevel,
                              lvl.Seq,
                              t.employee
                              ).ToList();
                            db.Dispose();
                        }
                    }
                    return sp;
                }

            }
            catch (Exception ex)
            {
                this._logger.Error("GetEmployeeLeaveRequestApproved " + ex.Message);
                return new List<LeaveHistory>();
            }
        }

        public object GetEmployeeLeaveRequestRejected(Inquiry t)
        {
            try
            {
                using (var hr = new hrm_projectContext())
                {
                    var sp = new List<LeaveHistory>();
                    var epm = (from c in hr.TbemployeeEmployments where c.Employee == t.employee select c).FirstOrDefault();
                    var elvl = (from c in hr.TbemployeeClassifications where c.Employee == t.employee select c).FirstOrDefault();
                    var lvl = (from c in hr.TbemployeeLevels where c.Id == elvl.EmployeeLevel select c).FirstOrDefault();

                    if (epm != null)
                    {
                        using (var db = new dbContext())
                        {
                            sp = db.SpSupervisorGetEmployeeLeaveRequestRejected.FromSqlRaw("CALL SpSupervisorGetEmployeeLeaveRequestRejected({0},{1},{2},{3},{4},{5},{6})",
                              t.company,
                              epm.Department,
                              epm.Division,
                              epm.Section,
                              elvl.EmployeeLevel,
                              lvl.Seq,
                              t.employee
                              ).ToList();
                            db.Dispose();
                        }
                    }
                    return sp;
                }

            }
            catch (Exception ex)
            {
                this._logger.Error("GetEmployeeLeaveRequestRejected " + ex.Message);
                return new List<LeaveHistory>();
            }
        }

        public object GetEmployeeLeaveRequestHrNeedApproval(Inquiry t)
        {
            //SpHrGetEmployeeLeaveRequest
            try
            {
                var sp = new List<LeaveHistory>();

                using (var db = new dbContext())
                {
                    sp = db.SpHrGetEmployeeLeaveRequest.FromSqlRaw("CALL SpHrGetEmployeeLeaveRequest({0})",
                      t.company
                      ).ToList();
                    db.Dispose();
                }
                return sp;

            }
            catch (Exception ex)
            {
                this._logger.Error("GetEmployeeLeaveRequestHrNeedApproval " + ex.Message);
                return new List<LeaveHistory>();
            }
        }

        public object GetEmployeeLeaveRequestHrApproved(Inquiry t)
        {
            try
            {
                var sp = new List<LeaveHistory>();

                using (var db = new dbContext())
                {
                    sp = db.SpHrGetEmployeeLeaveRequestApproved.FromSqlRaw("CALL SpHrGetEmployeeLeaveRequestApproved({0})",
                      t.company
                      ).ToList();
                    db.Dispose();
                }
                return sp;

            }
            catch (Exception ex)
            {
                this._logger.Error("GetEmployeeLeaveRequestHrApproved " + ex.Message);
                return new List<LeaveHistory>();
            }
        }

        public object GetEmployeeLeaveRequestHrRejected(Inquiry t)
        {
            try
            {
                var sp = new List<LeaveHistory>();
                using (var db = new dbContext())
                {
                    sp = db.SpHrGetEmployeeLeaveRequestRejected.FromSqlRaw("CALL SpHrGetEmployeeLeaveRequestRejected({0})",
                      t.company
                      ).ToList();
                    db.Dispose();
                }
                return sp;

            }
            catch (Exception ex)
            {
                this._logger.Error("GetEmployeeLeaveRequestHrRejected " + ex.Message);
                return new List<LeaveHistory>();
            }
        }

        public object GetEmployeeLeaveRemain(Inquiry t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var ls = (from c in db.TbemployeeLeaveSettings 
                              where c.EmployeeAnnualLeave == t.id && c.Employee == t.employee select c).FirstOrDefault();
                    if (ls == null)
                    {
                        var nls = new TbemployeeLeaveSetting
                        {
                            Employee = t.employee,
                            EmployeeAnnualLeave = t.id,
                            Ratio = 0,
                            Remain = 0
                        };
                        this.Create(nls);
                        throw new Exception("Leave Setting Not Found But Added");
                    }

                    return ls;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error("GetEmployeeLeaveRemain " + ex.Message);
                return new TbemployeeLeaveSetting();
            }
        }

        public object GetEmployeeLeaveCount(Inquiry t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var ls = (from c in db.TbemployeeLeaveSettings 
                              where c.Id == t.id && c.Employee == t.employee select c).FirstOrDefault();
                    if (ls == null)
                    {
                        var nls = new TbemployeeLeaveSetting
                        {
                            Employee = t.employee,
                            EmployeeAnnualLeave = t.id,
                            Ratio = 0,
                            Remain = 0
                        };
                        this.Create(nls);
                        throw new Exception("Leave Setting Not Found But Added");
                    }

                    return ls;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error("GetEmployeeLeaveRemain " + ex.Message);
                return new TbemployeeLeaveSetting();
            }
        }

        public object GetEmployeeLeaveSummary(Inquiry t)
        {
            try
            {
                var sp = new List<LeaveSummary>();
                using (var db = new dbContext())
                {
                    sp = db.SpEmployeeGetLeaveSummary.FromSqlRaw("CALL SpEmployeeGetLeaveSummary({0})", t.employee).ToList();
                    db.Dispose();
                }
                return sp;

            }
            catch (Exception ex)
            {
                this._logger.Error("GetEmployeeLeaveSummary " + ex.Message);
                return new List<LeaveSummary>();
            }
        }
    }
}
