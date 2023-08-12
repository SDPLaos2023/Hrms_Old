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
    public class BankInfoServices : IBankInfoServices
    {
        public BankInfoServices( IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(BankInfoServices));

        public IConfiguration Configuration { get; }
         
        public string Create(Tbbank t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string ID = NumberConstrol.GetNextNumber("B");
                    var d = new Tbbank();
                    d.Id = ID;
                    d.Name = t.Name;
                    d.NameEn = t.NameEn;
                    d.Code = t.Code;
                    d.Status = t.Status;
                    db.Tbbanks.Add(d);
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
                    var d = (from c in db.Tbbanks where c.Id == id select c).FirstOrDefault();
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

        public Tbbank Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbbanks where c.Id == id select c).FirstOrDefault();
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

        public IEnumerable<Tbbank> GetList()
        {
            var list = new List<Tbbank>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                   list = (from c in db.Tbbanks where c.Status != "DELETED" select c).ToList();

                    db.Dispose();
                    return list;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return list ;
            }
        }

        public string Update(string id, Tbbank t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbbanks where c.Id == id select c).FirstOrDefault();
                    d.Name = t.Name;
                    d.NameEn = t.NameEn;
                    d.Code = t.Code;
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
    }
}
