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
    public class DeviceUserFingerMappingServices : IDeviceUserFingerMappingServices
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(DeviceUserFingerMappingServices));
        public IConfiguration Configuration { get; }
        public DeviceUserFingerMappingServices(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public string Create(Tbfingerprintmapping t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string id = NumberConstrol.GetNextNumber("FX");
                    var d = new Tbfingerprintmapping();
                    d.Id = id;
                    d.FingerUserId = t.FingerUserId;
                    d.FingerIndex = t.FingerIndex;
                    d.FingerImg = t.FingerImg;
                    d.Status = t.Status;
                    db.Tbfingerprintmappings.Add(d);
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

        public string Delete(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbfingerprintmappings where c.Id == id select c).FirstOrDefault();
                    db.Tbfingerprintmappings.Remove(d);
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

        public Tbfingerprintmapping Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbfingerprintmappings where c.Id == id select c).FirstOrDefault();
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

        public IEnumerable<Tbfingerprintmapping> GetList(string id)
        {
            var list = new List<Tbfingerprintmapping>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                   
                    list = (from c in db.Tbfingerprintmappings where c.FingerUserId == id select c).ToList();
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

        public string Update(string id, Tbfingerprintmapping t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbfingerprintmappings where c.Id == id select c).FirstOrDefault();
                    d.FingerUserId = t.FingerUserId;
                    d.FingerIndex = t.FingerIndex;
                    d.FingerImg = t.FingerImg;
                    d.Status = t.Status;
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
    }
}
