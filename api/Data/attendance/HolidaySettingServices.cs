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
    public class HolidaySettingServices : IHolidaySettingServices
    {

        private readonly ILog _logger = LogManager.GetLogger(typeof(HolidaySettingServices));
        public IConfiguration Configuration { get; }
        public HolidaySettingServices(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public string Create(TbholidaySetting t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string id = NumberConstrol.GetNextNumber("HS");
                    var d = new TbholidaySetting
                    {
                        Id = id,
                        Name = t.Name,
                        Description = t.Description,
                        Date = t.Date,
                        IsDraft = t.IsDraft
                    };
                    db.TbholidaySettings.Add(d);
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
                    var d = (from c in db.TbholidaySettings where c.Id == id select c).FirstOrDefault();
                    db.TbholidaySettings.Remove(d);
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

        public TbholidaySetting Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbholidaySettings where c.Id == id select c).FirstOrDefault();
                    return d;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return null;
            }
        }

        public IEnumerable<TbholidaySetting> GetList(string year)
        {
            var list = new List<TbholidaySetting>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var dateform = new DateTime(int.Parse(year), 1, 1);
                    var dateEnd = new DateTime(int.Parse(year), 12, 31);
                    list = (from c in db.TbholidaySettings where c.Date >= dateform && c.Date <= dateEnd select c).ToList();
                    db.Dispose();
                    return list;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return null;
            }
        }

        public IEnumerable<TbholidaySetting> GetListDraff()
        {
            var list = new List<TbholidaySetting>();
            try
            {
                using (var db = new hrm_projectContext())
                {

                    list = (from c in db.TbholidaySettings where c.IsDraft == true select c).ToList();
                    db.Dispose();
                    return list;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return null;
            }
        }

        public string Update(string id, TbholidaySetting t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbholidaySettings where c.Id == id select c).FirstOrDefault();
                    d.Name = t.Name;
                    d.Description = t.Description;
                    d.Date = t.Date;
                    d.IsDraft = t.IsDraft;
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

        public object GetListHolidayByDate(Inquiry t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbholidaySettings where c.IsDraft == false && c.Date >= t.dateFrom.Date && c.Date <= t.dateTo.Date select c).ToList();

                    return d;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return new List<TbholidaySetting>();
            }
        }
    }
}
