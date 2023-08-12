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
    public class EmployeeTypeServices : IEmployeeTypeServices
    {
        public EmployeeTypeServices(IConfiguration configuration)
        {
            
            this.Configuration = configuration;

        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(EmployeeTypeServices));

        public IConfiguration Configuration { get; }

        public string Create(TbemployeeType wt)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string ID = NumberConstrol.GetNextNumber("EP");
                    var d = new TbemployeeType();
                    d.Id = ID;
                    d.Name = wt.Name;
                    d.NameEn = wt.NameEn;
                    d.Code = wt.Code;
                    d.Status = wt.Status;
                    db.TbemployeeTypes.Add(d);
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
                    var d = (from c in db.TbemployeeTypes where c.Id == id select c).FirstOrDefault();
                    d.Status = "DELETED";
                    db.SaveChanges();

                    var e = (from c in db.TbemployeeClassifications where c.EmployeeType == id select c).ToList();
                    e.ForEach(e => e.EmployeeType = "EP");
                    db.SaveChanges();
                    db.Dispose();
                }
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return "UNSUCCESS";
            }
        }

        public TbemployeeType Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeTypes where c.Id == id select c).FirstOrDefault();
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

        public IEnumerable<TbemployeeType> GetList()
        {
            var list = new List<TbemployeeType>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.TbemployeeTypes where c.Status != "DELETED" select c).ToList();
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

        public string Update(string id, TbemployeeType t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeTypes where c.Id == id select c).FirstOrDefault();
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
