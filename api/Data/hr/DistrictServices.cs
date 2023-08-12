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
    public class DistrictServices : IDistrictServices
    {
        public DistrictServices( IConfiguration configuration)
        {
            
            this.Configuration = configuration;
        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(DistrictServices));

        public IConfiguration Configuration { get; }

        public string Create(Tbdistrict t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string ID = NumberConstrol.GetNextNumber("DI");
                    var d = new Tbdistrict();
                    d.Id = ID;
                    d.Name = t.Name;
                    d.NameEn = t.NameEn;
                    d.Code = t.Code;
                    d.Status = t.Status;
                    d.Province = t.Province;
                    db.Tbdistricts.Add(d);
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
                    var d = (from c in db.Tbdistricts where c.Id == id select c).FirstOrDefault();
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

        public Tbdistrict Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbdistricts where c.Id == id select c).FirstOrDefault();
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

        public IEnumerable<Tbdistrict> GetList()
        {
            var list = new List<Tbdistrict>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.Tbdistricts where c.Status != "DELETED" select c).ToList();

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

        public string Update(string id, Tbdistrict t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbdistricts where c.Id == id select c).FirstOrDefault();
                    d.Name = t.Name;
                    d.NameEn = t.NameEn;
                    d.Code = t.Code;
                    d.Status = t.Status;
                    d.Province = t.Province;
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

        public IEnumerable<Tbdistrict> GetList(string id)
        {
            var list = new List<Tbdistrict>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.Tbdistricts where c.Province == id && c.Status != "DELETED" select c).ToList();

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
