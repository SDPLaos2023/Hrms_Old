using hrm_api.Models;
using hrm_api.Models.attendance;
using hrm_api.Services.Interfaces.attendance;
using log4net;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static hrm_api.Models.dbContext;
using hrm_api.Data.hr;
using MySql.Data.MySqlClient;

namespace hrm_api.Data.attendance
{
    public class TimesheetServices : ITimesheetService
    {
        private readonly ILog log = LogManager.GetLogger(typeof(TimesheetServices));
        public IConfiguration Configuration { get; }
        public TimesheetServices(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IEnumerable<Tbtimesheet> GetPersonTimesheet(TimesheetInq req)
        {
            var list = new List<Tbtimesheet>();
            try
            {
                var today = DateTime.Now;//.AddMonths(-4);
                var days = DateTime.DaysInMonth(today.Year, today.Month);
                var firstDay = req.datefrom.Date;// new DateTime(today.Year, today.Month, 1);
                var lastDay = req.dateto.Date;//new DateTime(today.Year, today.Month, days);

                log.Info(firstDay);
                log.Info(lastDay);

                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.Tbtimesheets where c.Employee == req.employee && c.AttDate >= firstDay && c.AttDate <= lastDay select c).OrderBy(o => o.AttDate).ThenBy(o => o.ClockIn).ToList();
                    db.Dispose();
                    return list;
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return list;
            }
        }

        public object GetAttendanceByDepartment(TimesheetInq req)
        {
            //var list = new List<Tbtimesheet>();
            try
            {

                using (var db = new hrm_projectContext())
                {

                    var employments = (from employment in db.TbemployeeEmployments
                                       join dept in db.Tbdepartments on employment.Department equals dept.Id
                                       join section in db.Tbsections on employment.Section equals section.Id
                                       select new
                                       {
                                           Id = employment.Id,
                                           Department = employment.Department,
                                           DepartmentName = dept.Name,
                                           Section = section.Id,
                                           SectionName = section.Name,
                                           Employee = employment.Employee

                                       });

                    var employeesRaw = (from employee in db.Tbemployees select employee);
                    var fpUsers = (from f in db.Tbfpusers select f);
                    var employees = (from employee in employeesRaw
                                     join employment in employments on employee.Id equals employment.Employee
                                     join fpuser in fpUsers on employee.Id equals fpuser.Employee
                                     where employment.Department == req.department && employee.Status != "DELETED"
                                     select new
                                     {
                                         Emlpoyee = employee.Id,
                                         EmployeeName = employee.Name,
                                         Department = employment.Department,
                                         DepartmentName = employment.DepartmentName,
                                         Section = employment.Section,
                                         SectionName = employment.SectionName,
                                         FpUserId = fpuser.FpUserId
                                     });

                    var list = (from ts in db.Tbtimesheets
                                join employee in employees
                                on ts.Employee equals employee.Emlpoyee
                                where (ts.AttDate >= (DateTime)req.datefrom) && (ts.AttDate <= (DateTime)req.dateto)
                                select new
                                {
                                    Id = ts.Id,
                                    EmployeeName = employee.EmployeeName,
                                    Employee = employee.Emlpoyee,
                                    Department = employee.Department,
                                    DepartmentName = employee.DepartmentName,
                                    Section = employee.Section,
                                    SectionName = employee.SectionName,
                                    ClockIn = ts.ClockIn,
                                    ClockOut = ts.ClockOut,
                                    Remark = ts.Remark,
                                    RawIn = ts.RawIn,
                                    RawOut = ts.RawOut,
                                    AttDate = ts.AttDate,
                                    FpUserId = employee.FpUserId
                                }

                        ).OrderBy(o => o.Department).ThenBy(o => o.Employee).ThenBy(o => o.AttDate).ThenBy(o => o.ClockIn)
                        .ToList();
                    db.Dispose();

                    return list;
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return null;
            }
        }
        //att.AttTime
        //var noon = new TimeSpan(12,30,00);|| att.AttTime <= noon
        public object UploadAttendanceLog(List<Tbattlog> req)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {

                    foreach (var att in req)
                    {

                        att.Id = NumberConstrol.GetNextNumber("AT");
                        att.AttCode = "997";
                        //var isExists = this.checkDuplicate(att);
                        //if (!isExists)
                        //{
                        //    string id = 
                        //    att.Id = id;
                        //    db.Tbattlogs.Add(att);
                        //    var dd = db.SaveChangesAsync();

                        //}

                        //this.AddTimeSheetRecord(att.AttDate.Value.Date, att.FpUserId, att.FpId);
                    }

                    db.Tbattlogs.AddRange(req);
                    db.SaveChanges();
                    db.Dispose();
                }
                return "OK";
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return null;
            }
        }

        private bool checkDuplicate(Tbattlog att)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var count = (from t in db.Tbattlogs where t.AttDate == att.AttDate && t.AttTime == att.AttTime && t.FpUserId == att.FpUserId && t.FpId == att.FpId select t).ToList();

                    if (count.Count > 0)
                        return true;
                    //else return true;
                    db.Dispose();
                }
            }
            catch (Exception ex)
            {
                log.Info(ex.Message);
                return false;
            }
            return false;
        }

        public object Tests()
        {
            using (var db = new hrm_projectContext())
            {
                var tt = (from t in db.Tbattlogs select t).ToList();
                foreach (var item in tt)
                {
                    var fpu = (from t in db.Tbfpusers where t.FpUserId == item.FpUserId select t).FirstOrDefault();
                    var employee = fpu.Employee;
                    var date = item.AttDate.Value.Date;
                    var FpUserId = item.FpUserId;
                    this.DoClockIn(employee, date, FpUserId);
                    this.DoClockOut(employee, date, FpUserId);
                }

                db.DisposeAsync();
                return "OK";
            }
        }

        private void AddTimeSheetRecord(DateTime AttDate, string fpUserId, string fpId)
        {
            try
            {

                using (var db = new hrm_projectContext())
                {
                    //user from fingerprint user
                    var fpu = (from t in db.Tbfpusers where t.FpUserId == fpUserId && t.FpId == fpId select t).FirstOrDefault();

                    if (fpu != null)
                    {
                        var employee = fpu.Employee;
                        this.CreatTsRecord(employee, AttDate);
                        this.DoClockIn(employee, AttDate, fpUserId);
                        this.DoClockOut(employee, AttDate, fpUserId);
                    }

                    db.DisposeAsync();
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void DoClockOut(string employee, DateTime attDate, string fpUserId)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var ts = (from t in db.Tbtimesheets where t.Employee == employee && t.AttDate.Value.Date == attDate.Date select t).OrderByDescending(o => o.AttDate).FirstOrDefault();

                    var wa = (from t in db.TbtimeAssigments
                              where t.Employee == employee && (t.StartedAt.Value.Date >= attDate.Date && t.EndedAt.Value.Date <= attDate.Date)
                              select t).FirstOrDefault();

                    var tt = (from t in db.Tbtimetables where t.Id == "TT00001" select t).FirstOrDefault();

                    if (wa != null)
                    {
                        tt = (from t in db.Tbtimetables where t.Id == wa.Timetable select t).FirstOrDefault();
                    }

                    if (ts != null)
                    {
                        string status = "MAX";
                        DateTime clocking = this.GetMaxMinTimeOnDate(attDate, fpUserId, status);
                        DateTime D1990 = new DateTime(1990, 1, 1);
                        var timeOut = (TimeSpan)tt.StartOut;// new TimeSpan(8, 00, 00);
                        var EOut = (int)tt.EarlyOut;

                        var min = timeOut - clocking.TimeOfDay;
                        var isEarly = (min.TotalMinutes - EOut) * -1 <= 0 ? true : false;
                        var earlyOut = 0d;
                        if (isEarly)
                        {

                            earlyOut = min.TotalMinutes;
                        }

                        if (clocking.Date != D1990.Date)
                        {
                            ts.AttDate = attDate;
                            ts.ClockOut = clocking.TimeOfDay;
                            ts.RawOut = clocking.TimeOfDay;
                            ts.EarlyMin = (int)earlyOut;
                            db.SaveChangesAsync();
                        }
                    }
                    db.DisposeAsync();
                }
            }
            catch (Exception ex)
            {
                log.Error("Do clock out error :" + ex.Message);
            }
        }

        private void DoClockIn(string employee, DateTime attDate, string fpUserId)
        {
            try
            {

                using (var db = new hrm_projectContext())
                {
                    var ts = (from t in db.Tbtimesheets where t.Employee == employee && t.AttDate.Value.Date == attDate.Date select t).OrderByDescending(o => o.AttDate).FirstOrDefault();

                    var wa = (from t in db.TbtimeAssigments
                              where t.Employee == employee && (t.StartedAt.Value.Date >= attDate.Date && t.EndedAt.Value.Date <= attDate.Date)
                              select t).FirstOrDefault();

                    var tt = (from t in db.Tbtimetables where t.Id == "TT00001" select t).FirstOrDefault();

                    if (wa != null)
                    {
                        tt = (from t in db.Tbtimetables where t.Id == wa.Timetable select t).FirstOrDefault();
                    }

                    if (ts != null)
                    {
                        string status = "MIN";
                        DateTime clocking = this.GetMaxMinTimeOnDate(attDate, fpUserId, status);
                        var timeIn = (TimeSpan)tt.StartIn;// new TimeSpan(8, 00, 00);
                        var lMin = (int)tt.LateIn;
                        DateTime D1990 = new DateTime(1990, 1, 1);
                        var min = timeIn - clocking.TimeOfDay;
                        var latemin = min.TotalMinutes < 0 ? min.TotalMinutes * -1 : min.TotalMinutes;
                        var late = latemin - lMin <= 0 ? 0 : latemin;

                        if (clocking.Date != D1990.Date)
                        {
                            ts.AttDate = attDate;
                            ts.ClockIn = clocking.TimeOfDay;
                            ts.RawIn = clocking.TimeOfDay;
                            ts.LateMin = (int)late;
                            db.SaveChangesAsync();
                        }
                    }
                    db.DisposeAsync();
                }
            }
            catch (Exception ex)
            {
                log.Error("Do clock in error :" + ex.Message);
            }
        }

        private DateTime GetMaxMinTimeOnDate(DateTime attDate, string fpUserId, string status)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var attLog = (from t in db.Tbattlogs
                                  where t.AttDate == attDate && t.FpUserId == fpUserId
                                  select t).ToList();
                    if (attLog.Count > 0)
                    {
                        if (status == "MIN")
                        {

                            if (attLog.First().AttTime == null)
                            {
                                throw new Exception("NOK");
                            }

                            var f = (TimeSpan)attLog.First().AttTime;
                            return attDate + f;
                        }
                        else
                        {
                            if (attLog.OrderByDescending(d => d.AttTime).First().AttTime == null)
                            {
                                throw new Exception("NOK");
                            }
                            var f = (TimeSpan)attLog.OrderByDescending(d => d.AttTime).First().AttTime;
                            return attDate + f;
                        }
                    }
                    db.Dispose();
                }

            }
            catch (Exception ex)
            {
                log.Error(string.Format("Get {0} error :{1}", status, ex.Message));
                return new DateTime(1990, 1, 1);
            }

            return new DateTime(1990, 1, 1);

        }

        private void CreatTsRecord(string employee, DateTime attDate)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var ts = (from t in db.Tbtimesheets where t.Employee == employee && t.AttDate == attDate.Date select t).FirstOrDefault();
                    if (ts != null) return;

                    string id = NumberConstrol.GetNextNumber("TS");
                    var attlog = new Tbtimesheet
                    {
                        Id = id,
                        AttDate = attDate,
                        Employee = employee
                    };
                    db.Tbtimesheets.Add(attlog);
                    db.SaveChangesAsync();
                    db.DisposeAsync();
                    return;
                }
            }
            catch (Exception ex)
            {
                log.Error("Create timesheet record :" + ex.Message);
            }
        }

        public object RecalculateData(List<FpRecalculateRequest> l)
        {
            try
            {
                log.Info(JsonConvert.SerializeObject(l));

                using (var db = new hrm_projectContext())
                {
                    foreach (var req in l)
                    {
                        log.Info(JsonConvert.SerializeObject(req));

                        var list = (from t in db.Tbattlogs
                                    where t.FpUserId == req.FpUserId &&
            (t.AttDate.Value.Date >= req.DateFrom.Date && t.AttDate.Value.Date <= req.DateTo.Date)
                                    select t).ToList();
                        log.Info(JsonConvert.SerializeObject(list));


                        var fpu = (from t in db.Tbfpusers where t.FpUserId == req.FpUserId select t).FirstOrDefault();
                        log.Info(JsonConvert.SerializeObject(fpu));

                        if (fpu != null)
                        {
                            var employee = fpu.Employee;
                            foreach (var item in list)
                            {
                                var date = item.AttDate.Value.Date;
                                var FpUserId = item.FpUserId;
                                this.DoClockIn(employee, date, FpUserId);
                                this.DoClockOut(employee, date, FpUserId);
                            }
                        }
                    }
                    db.Dispose();
                }
                return "OK";
            }
            catch (Exception ex)
            {
                log.Error("Recalculate timsheet" + ex.Message);
                return "NOK";
            }
        }

        public object GetTimesheetByDate(TimesheetInq t)
        {
            try
            {
                log.Info(JsonConvert.SerializeObject(t));
                //var emp = "";
                //using (var db = new hrm_projectContext())
                //{
                //    emp = (from d in db.Tbemployees
                //           join e in db.TbemployeeEmployments on d.Id equals e.Employee
                //           where d.Id == t.employee && e.Department == t.department
                //           select d.Id).FirstOrDefault();
                //    if (emp != null)
                //        t.employee = emp;
                //    else throw new Exception("No employee found");

                //    db.Dispose();
                //}

                using (var db = new dbContext())
                {
                    var d = db.SpDepartmentTimesheets.FromSqlRaw("CALL employeetimesheetmonthly({0},{1},{2})",
                        t.datefrom, t.dateto, t.employee).ToList();
                    db.Dispose();
                    return d;
                }
            }
            catch (Exception ex)
            {
                log.Error("Get timsheet by date " + ex.Message);
                return new List<DepartmentTimesheet>();
            }
        }

        public object GetAllTimesheetMonthly(TimesheetInq t)
        {
            try
            {
                log.Info(JsonConvert.SerializeObject(t));

                using (var db = new dbContext())
                {

                    var df = t.datefrom.ToString("yyyy-MM-dd");
                    var dt = t.dateto.ToString("yyyy-MM-dd");
                    var dept = t.department == "D" ? "%%" : t.department;

                    var d = db.SpDepartmentTimesheets.FromSqlRaw("CALL departmenttimesheetmonthly({0},{1},{2})"
                        ,
                        df, dt, dept
                        ).ToList();
                    db.Dispose();
                    return d;
                }
            }
            catch (Exception ex)
            {
                log.Error("Get timsheet monthly " + ex.Message);
                return new List<DepartmentTimesheet>();
                //return "NOK";
            }
        }

        public object AddTime(List<AddTimeRequest> ls)
        {
            //add clockin
            //add clockout
            //add timesheet
            try
            {
                using (var db = new hrm_projectContext())
                {
                    foreach (var t in ls)
                    {
                        var clockin = new Tbattlog
                        {
                            Id = NumberConstrol.GetNextNumber("AT"),
                            FpId = t.FpId,
                            AttDate = t.AttDate,
                            AttTime = t.ClockIn,
                            AttCode = t.AttCode,
                            FpUserId = t.FpUserId
                        };

                        var clockout = new Tbattlog
                        {
                            Id = NumberConstrol.GetNextNumber("AT"),
                            FpId = t.FpId,
                            AttDate = t.AttDate,
                            AttTime = t.ClockOut,
                            AttCode = t.AttCode,
                            FpUserId = t.FpUserId
                        };
                        var list = new List<Tbattlog> { clockin, clockout };

                        db.Tbattlogs.AddRange(list);
                        db.SaveChanges();

                        var emp = (from c in db.Tbfpusers where c.FpUserId == t.FpUserId select c.Employee).FirstOrDefault();

                        var ts = (from c in db.Tbtimesheets where c.AttDate == t.AttDate && c.Employee == emp select c).FirstOrDefault();
                        if (ts != null)
                        {
                            ts.ClockIn = t.ClockIn;
                            ts.ClockOut = t.ClockOut;
                            ts.Remark = t.AttCode;
                            db.SaveChanges();

                        }
                        else
                        {
                            string id = NumberConstrol.GetNextNumber("TS");
                            ts = new Tbtimesheet
                            {
                                Id = id,
                                AttDate = t.AttDate,
                                ClockIn = t.ClockIn,
                                ClockOut = t.ClockOut,
                                RawIn = t.ClockIn,
                                RawOut = t.ClockOut,
                                Remark = t.AttCode,
                                Employee = emp,
                                ClockStatus = t.AttCode
                            };
                            db.Tbtimesheets.Add(ts);
                            db.SaveChanges();
                        }

                    }
                    db.Dispose();
                }
                return "OK";
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return "NOK";
            }
        }

        public object GetTimesheetByFpUser(AddTimeRequest t)
        {

            try
            {
                using (var db = new hrm_projectContext())
                {
                    var fp = (from c in db.Tbfpusers where c.FpUserId == t.FpUserId select c).FirstOrDefault();
                    var ts = (from c in db.Tbtimesheets where c.AttDate == t.AttDate && c.Employee == fp.Employee select c).FirstOrDefault();
                    var empOjb = (from e in db.TbemployeeEmployments
                                  join d in db.Tbdepartments on e.Department equals d.Id
                                  join s in db.Tbsections on e.Section equals s.Id
                                  join ee in db.Tbemployees on e.Employee equals ee.Id
                                  where e.Employee == fp.Employee
                                  select new
                                  {
                                      employment = e,
                                      department = d,
                                      section = s,
                                      employee = ee
                                  }).FirstOrDefault();

                    t.Employee = fp.Employee;
                    t.EmployeeName = empOjb.employee.Name;
                    t.FpId = fp.FpId;
                    t.FpUserId = fp.FpUserId;
                    t.AttCode = "999";
                    t.Department = empOjb.department.Id;
                    t.DepartmentName = empOjb.department.Name;
                    t.Section = empOjb.section.Id;
                    t.SectionName = empOjb.section.Name;
                    if (ts != null)
                    {
                        t.ClockIn = (TimeSpan)ts.ClockIn;
                        t.ClockOut = (TimeSpan)ts.ClockOut;
                    }
                    db.Dispose();
                    return t;
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
            }
            return t;
        }

        public object GetUserTimesheetByDate(TimesheetInq t)
        {
            try
            {
                log.Info(JsonConvert.SerializeObject(t));



                using (var db = new dbContext())
                {
                    var d = db.SpDepartmentTimesheets.FromSqlRaw("CALL employeetimesheetmonthly({0},{1},{2})",
                        t.datefrom, t.dateto, t.employee).ToList();
                    db.Dispose();
                    return d;
                }
            }
            catch (Exception ex)
            {
                log.Error("GetUserTimesheetByDate " + ex.Message);
                return new List<DepartmentTimesheet>();
                //return "NOK";
            }
        }

        public object UpdateTimesheet(List<Timesheet> t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    foreach (var item in t)
                    {
                        var ts = (from c in db.Tbtimesheets where c.Id == item.Id select c).FirstOrDefault();
                        ts.ClockIn = item.ClockIn;
                        ts.ClockOut = item.ClockOut;
                        ts.Remark = "998";
                        ts.ClockStatus = "998";
                        db.SaveChanges();
                    }
                    db.Dispose();
                }

            }
            catch (Exception ex)
            {

                this.log.Error("UpdateTimesheet " + ex.Message);
                return "NOK";
            }

            return "OK";
        }

        public object AddLog(List<AddTimeRequest> t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    foreach (var item in t)
                    {
                        string FpId = (from c in db.Tbfpusers where c.FpUserId == item.FpUserId select c.FpId).FirstOrDefault();
                        var clockin = new Tbattlog
                        {
                            Id = NumberConstrol.GetNextNumber("AT"),
                            FpId = FpId,
                            AttDate = item.AttDate,
                            AttTime = item.ClockIn,
                            AttCode = item.AttCode,
                            FpUserId = item.FpUserId
                        };
                        db.Tbattlogs.Add(clockin);
                        db.SaveChanges();

                        var clockout = new Tbattlog
                        {
                            Id = NumberConstrol.GetNextNumber("AT"),
                            FpId = FpId,
                            AttDate = item.AttDate,
                            AttTime = item.ClockOut,
                            AttCode = item.AttCode,
                            FpUserId = item.FpUserId
                        };
                        db.Tbattlogs.Add(clockout);
                        db.SaveChanges();
                    }

                    db.Dispose();
                }

            }
            catch (Exception ex)
            {

                this.log.Error("UpdateTimesheet " + ex.Message);
                return "NOK";
            }

            return "OK";
        }

        public object CalculateAttendance(CalculateAttendanceRequest t)
        {
            try
            {
                using (var db = new dbContext())
                {
                    var sp = db.SpCalculateAttendance.FromSqlRaw("CALL calculateAttendance({0},{1},{2},{3})",
                       t.ids, t.creator, t.asofdate, t.company).ToList();
                    this.log.Info(sp);
                    db.Dispose();
                    return sp;
                }
            }
            catch (Exception ex)
            {
                this.log.Error("UpdateTimesheet " + ex.Message);
                return new List<CalculateAttendanceResponse>();
            }
        }

        public object GetWorkingPeriodList(string company)
        {
            try
            {
                using (var db = new dbContext())
                {
                    var sp = db.SpWorkingperiod.FromSqlRaw("CALL getallworkingperiod({0})",
                       company).ToList();
                    db.Dispose();
                    return sp;
                }
            }
            catch (Exception ex)
            {
                this.log.Error("UpdateTimesheet " + ex.Message);
                return new List<CalculateAttendanceResponse>();
            }
        }

        public object NewWorkingPeriod(Tbworkingperiod t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string id = NumberConstrol.GetNextNumber("WKP");
                    var d = new Tbworkingperiod();
                    d.Id = id;
                    d.Name = t.Name;
                    d.Company = t.Company;
                    d.StartedAt = t.StartedAt;
                    d.EndedAt = t.EndedAt;
                    d.Total = t.Total;
                    d.WorkingHrs = t.WorkingHrs;
                    d.CreatedAt = DateTime.Now;
                    d.CreatedBy = t.CreatedBy;
                    d.Status = t.Status;
                    db.Tbworkingperiods.Add(d);
                    db.SaveChanges();
                    db.Dispose();
                    return "success";
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return "unsuccess";
            }
        }

        public object UpdateWorkingPeriod(Tbworkingperiod t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbworkingperiods where c.Id == t.Id select c).FirstOrDefault();
                    d.Name = t.Name;
                    d.Company = t.Company;
                    d.StartedAt = t.StartedAt;
                    d.EndedAt = t.EndedAt;
                    d.Total = t.Total;
                    d.WorkingHrs = t.WorkingHrs;
                    d.UpdatedAt = DateTime.Now;
                    d.UpdatedBy = t.CreatedBy;
                    d.Status = t.Status;
                    db.Tbworkingperiods.Add(d);
                    db.SaveChanges();
                    db.Dispose();
                    return "success";
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return "unsuccess";
            }
        }

        public object ActiveWorkingPeriod(string wkpid)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var wkp = (from w in db.Tbworkingperiods where w.Id == wkpid select w).FirstOrDefault();
                    if (wkp != null)
                    {

                        wkp.Status = "ACTIVE";
                        wkp.UpdatedAt = DateTime.Now;
                        wkp.UpdatedBy = "";
                        db.SaveChanges();

                        var emps = (from e in db.Tbemployees where e.Company == wkp.Company select e).ToList();
                        foreach (var item in emps)
                        {
                            if (item.Status == "ACTIVE" && item.Code != "")
                            {
                                var check = (from c in db.TbemployeeWorkingPeriods
                                             where c.FpUserId == item.Code && c.WorkingPeriod == wkp.Id
                                             select c).FirstOrDefault();
                                if (check == null)
                                {
                                    string id = NumberConstrol.GetNextNumber("EWP");
                                    var ewp = new TbemployeeWorkingPeriod
                                    {
                                        Id = id,
                                        FpUserId = item.Code,
                                        WorkingPeriod = wkp.Id
                                    };
                                    db.TbemployeeWorkingPeriods.Add(ewp);
                                    db.SaveChanges();
                                }
                            }
                        }
                    }
                    db.Dispose();
                    return "success";
                }
            }
            catch (Exception ex)
            {
                this.log.Error("ActiveWorkingPeriod " + ex.Message);
                return "unsuccess";
            }
        }

        public object GetUserWorkingPeriod(string fpuserid)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var ewkp = (from ew in db.TbemployeeWorkingPeriods where ew.FpUserId == fpuserid select ew).FirstOrDefault();
                    object wkp = null;
                    if (ewkp != null)
                    {
                        wkp = (from w in db.Tbworkingperiods where w.Id == ewkp.WorkingPeriod select w).FirstOrDefault();
                    }
                    return wkp;
                }
            }
            catch (Exception ex)
            {
                this.log.Error("GetUserWorkingPeriod " + ex.Message);
                return null;
            }
        }

        public object GetEmployeeTimeAssignment(string employee)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var ta = (from eta in db.TbtimeAssigments where eta.Employee == employee select eta).FirstOrDefault();
                    object tt = null;
                    if (ta != null)
                    {
                        tt = (from t in db.Tbtimetables where t.Id == ta.Timetable select t).FirstOrDefault();
                    }
                    return tt;
                }
            }
            catch (Exception ex)
            {
                this.log.Error("GetTimeAssignment " + ex.Message);
                return null;
            }
        }
    }
}
