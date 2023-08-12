using hrm_api.Models;
using hrm_api.Services.Interfaces.attendance;
using log4net;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Data.attendance
{
    public class TimetableServices : ITimetableServices
    {

        private readonly ILog _logger = LogManager.GetLogger(typeof(TimetableServices));
        public IConfiguration Configuration { get; }
        public TimetableServices(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public string Create(Tbtimetable req)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string id = NumberConstrol.GetNextNumber("TT");
                    var d = new Tbtimetable
                    {
                        Id = id,
                        Name = req.Name,
                        StartIn = req.StartIn,
                        StartOut = req.StartOut,
                        LateIn = req.LateIn,
                        EarlyOut = req.EarlyOut,
                        BreakIn = req.BreakIn,
                        BreakOut = req.BreakOut,
                        DayOfWeek = req.DayOfWeek,
                        Status = req.Status
                    };
                    db.Tbtimetables.Add(d);
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

        public string Delete(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbtimetables where c.Id == id select c).FirstOrDefault();
                    d.Status = "DELETED";
                    db.SaveChanges();

                    var e = (from c in db.TbtimeAssigments where c.Timetable == id select c).ToList();
                    e.ForEach(e => e.Timetable = null);
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

        public object GetList()
        {
            var list = new List<Tbtimetable>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.Tbtimetables where c.Status != "DELETED" select c).ToList();
                    db.Dispose();
                    return list;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return list;
            }
        }

        public string Update(string id, Tbtimetable req)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbtimetables where c.Id == id select c).FirstOrDefault();
                    d.Name = req.Name;
                    d.StartIn = req.StartIn;
                    d.StartOut = req.StartOut;
                    d.LateIn = req.LateIn;
                    d.EarlyOut = req.EarlyOut;
                    d.BreakIn = req.BreakIn;
                    d.BreakOut = req.BreakOut;
                    d.DayOfWeek = req.DayOfWeek;
                    d.Status = req.Status;
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

        public object CreateShift(Tbshiftmanagement t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string id = NumberConstrol.GetNextNumber("SHF");
                    var d = new Tbshiftmanagement
                    {
                        Id = id,
                        Shiftname = t.Shiftname,
                        Workingday = t.Workingday,
                        Status = t.Status,
                        Company = t.Company,
                        CreatedAt = t.CreatedAt,
                        CreatedBy = t.CreatedBy
                    };
                    db.Tbshiftmanagements.Add(d);
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

        public object UpdateShift(Tbshiftmanagement t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from s in db.Tbshiftmanagements where s.Id == t.Id select s).FirstOrDefault();
                    if (d != null)
                    {
                        d.Shiftname = t.Shiftname;
                        d.Workingday = t.Workingday;
                        d.Status = t.Status;
                        d.UpdatedAt = t.UpdatedAt;
                        d.UpdatedBy = t.UpdatedBy;

                    }
                    else throw new Exception("shift not found");

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

        public object DeleteShift(Tbshiftmanagement t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from s in db.Tbshiftmanagements where s.Id == t.Id select s).FirstOrDefault();
                    if (d != null)
                    {
                        d.Status = t.Status;
                        d.UpdatedAt = t.UpdatedAt;
                        d.UpdatedBy = t.UpdatedBy;
                    }
                    else throw new Exception("shift not found");

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

        public object GetAllShift(Inquiry inq)
        {
            var list = new List<Tbshiftmanagement>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.Tbshiftmanagements where c.Status != "DELETED" && c.Company == inq.company select c).ToList();
                    db.Dispose();
                    return list;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return list;
            }
        }

        public object CreateShiftDetail(List<Tbshiftdetail> t)
        {
            try
            {

                using (var db = new hrm_projectContext())
                {
                    foreach (var item in t)
                    {

                        string id = NumberConstrol.GetNextNumber("SHD");
                        var d = new Tbshiftdetail
                        {
                            Id = id,
                            Shift = item.Shift,
                            Weekday = item.Weekday,
                            Timetable = item.Timetable
                        };
                        db.Tbshiftdetails.Add(d);
                        db.SaveChanges();

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

        public object UpdateShiftDetail(Tbshiftdetail t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {

                    var d = (from c in db.Tbshiftdetails where c.Id == t.Id select c).FirstOrDefault();
                    if (d != null)
                    {
                        d.Shift = t.Shift;
                        d.Weekday = t.Weekday;
                        d.Timetable = t.Timetable;
                        db.SaveChanges();

                    }
                    else throw new Exception("shift detail not found");
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

        public object DeleteShiftDetail(Tbshiftdetail t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {

                    var d = (from c in db.Tbshiftdetails where c.Id == t.Id select c).FirstOrDefault();
                    if (d != null)
                    {
                        db.Tbshiftdetails.Remove(d);
                        db.SaveChanges();

                    }
                    else throw new Exception("shift detail not found");
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

        public object GetAllShiftDetailList(Inquiry inquiry)
        {
            var list = new List<Tbshiftdetail>();
            try
            {
                using (var db = new hrm_projectContext())
                {

                    list = (from c in db.Tbshiftdetails where c.Shift == inquiry.id select c).ToList();
                    db.Dispose();
                    return list;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return list;
            }
        }
    }
}
