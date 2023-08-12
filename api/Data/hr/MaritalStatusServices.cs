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
    public class MaritalStatusServices : IMaritalStatusServices
    {
        public MaritalStatusServices(IConfiguration configuration)
        {
            
            this.Configuration = configuration;

        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(MaritalStatusServices));

        public IConfiguration Configuration { get; }

        public string Create(Tbmarriage mrts)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string ID = NumberConstrol.GetNextNumber("MR");
                    var d = new Tbmarriage();
                    d.Id = ID;
                    d.Name = mrts.Name;
                    d.NameEn = mrts.NameEn;
                    d.Code = mrts.Code;
                    d.Status = mrts.Status;
                    db.Tbmarriages.Add(d);
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
                    var d = (from c in db.Tbmarriages where c.Id == id select c).FirstOrDefault();
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

        public Tbmarriage Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbmarriages where c.Id == id select c).FirstOrDefault();
                    db.Dispose();
                    return d;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return null ;
            }
        }

        public IEnumerable<Tbmarriage> GetList()
        {
            var list = new List<Tbmarriage>();
            try
            {
                using (var db = new hrm_projectContext())
                {

                    list = (from c in db.Tbmarriages where c.Status !="DELETED" select c).ToList();
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

        public string Update(string id, Tbmarriage mrts)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbmarriages where c.Id == id select c).FirstOrDefault();
                    d.Name = mrts.Name;
                    d.NameEn = mrts.NameEn;
                    d.Code = mrts.Code;
                    d.Status = mrts.Status;
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
