using hrm_api.Models;
using hrm_api.Services.Interfaces.hr;
using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Data.hr
{
    public class BloodGroupServices : IBloodGroupServices
    {
        public BloodGroupServices( IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(BloodGroupServices));

        public IConfiguration Configuration { get; }

        public string Create(Tbbloodgroup tbbloodgroup)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string ID = NumberConstrol.GetNextNumber("BG");
                    tbbloodgroup.Id = ID;
                    db.Tbbloodgroups.Add(tbbloodgroup);
                    db.SaveChanges();
                    db.Dispose();
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
            }
            return "UNSUCCESS";
        }

        public string Delete(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var bg = (from c in db.Tbbloodgroups where c.Id == id select c).FirstOrDefault();
                    bg.Status = "DELETED";
                    db.SaveChanges();
                    db.Dispose();
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {

                this._logger.Error(ex.Message);
            }
            return "UNSUCCESS";
        }

        public Tbbloodgroup Get(string id)
        {
            var bg = new Tbbloodgroup();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    bg = (from c in db.Tbbloodgroups where c.Id ==id select c).FirstOrDefault();
                    db.Dispose();
                    return bg;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
            }

            return bg;
        }

        public IEnumerable<Tbbloodgroup> GetList()
        {
            var list = new List<Tbbloodgroup>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.Tbbloodgroups where c.Status !="DELETED" select c).ToList();
                    db.Dispose();
                    return list;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
            }

            return list ;
        }

        public string Update(string id, Tbbloodgroup req)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var bg = (from c in db.Tbbloodgroups where c.Id == id select c).FirstOrDefault();
                    bg.Name = req.Name;
                    bg.NameEn = req.NameEn;
                    bg.Code = req.Code;
                    bg.Status = req.Status;
                    db.SaveChanges();
                    db.Dispose();
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
            }
            return "UNSUCCESS";
        }
    }
}
