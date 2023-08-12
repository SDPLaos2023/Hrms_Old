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
    public class DeviceManagerServices : IDeviceManagerServices
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(DeviceManagerServices));
        public IConfiguration Configuration { get; }
        public DeviceManagerServices(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public string Create(Tbfingerprint t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string id = NumberConstrol.GetNextNumber("FM");
                    var d = new Tbfingerprint();
                    d.Id = id;
                    d.Name = t.Name;
                    d.IpAddress = t.IpAddress;
                    d.Port = t.Port;
                    d.Sn = t.Sn;
                    d.Mac = t.Mac;
                    d.Remark = t.Remark;
                    d.Status = t.Status;
                    db.Tbfingerprints.Add(d);
                    db.SaveChanges();
                    db.Dispose();
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return null;
            }
        }

        public string Update(string id, Tbfingerprint t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbfingerprints where c.Id == id select c).FirstOrDefault();
                    d.Name = t.Name;
                    d.IpAddress = t.IpAddress;
                    d.Port = t.Port;
                    d.Sn = t.Sn;
                    d.Mac = t.Mac;
                    d.Remark = t.Remark;
                    d.Status = t.Status;
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
                    var d = (from c in db.Tbfingerprints where c.Id == id select c).FirstOrDefault();
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

        public IEnumerable<Tbfingerprint> GetList()
        {
            var list = new List<Tbfingerprint>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = db.Tbfingerprints.Where(e => e.Status != "DELETED").ToList();
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

        public Tbfingerprint Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbfingerprints where c.Id == id select c).FirstOrDefault();
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
    }
}
