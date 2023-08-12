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
    public class WorkingTypeServices : IWorkingTypeServices
    {
        public WorkingTypeServices(IConfiguration configuration)
        {
            
            this.Configuration = configuration;

        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(WorkingTypeServices));

        public IConfiguration Configuration { get; }

        public string Create(TbworkingType wt)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string ID = NumberConstrol.GetNextNumber("WP");
                    var d = new TbworkingType();
                    d.Id = ID;
                    d.Name = wt.Name;
                    d.NameEn = wt.NameEn;
                    d.Code = wt.Code;
                    d.Status = wt.Status;
                    db.TbworkingTypes.Add(d);
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
                    var d = (from c in db.TbworkingTypes where c.Id == id select c).FirstOrDefault();
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

        public TbworkingType Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbworkingTypes where c.Id == id select c).FirstOrDefault();
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

        public IEnumerable<TbworkingType> GetList()
        {
            var list = new List<TbworkingType>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.TbworkingTypes where c.Status != "DELETED" select c).ToList();
                    db.Dispose();
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return list;
            }
            return list;
        }

        public string Update(string id, TbworkingType wt)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbworkingTypes where c.Id == id select c).FirstOrDefault();
                    d.Name = wt.Name;
                    d.NameEn = wt.NameEn;
                    d.Code = wt.Code;
                    d.Status = wt.Status;
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
