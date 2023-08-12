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
    public class EmployeeCategoryServices : IEmployeeCategoryServices
    {

        public EmployeeCategoryServices(IConfiguration configuration)
        {
            
            this.Configuration = configuration;
        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(EmployeeCategoryServices));

        public IConfiguration Configuration { get; }

        public string Create(TbemployeeCatagory t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string ID = NumberConstrol.GetNextNumber("ECA");
                    var d = new TbemployeeCatagory();
                    d.Id = ID;
                    d.Name = t.Name;
                    d.NameEn = t.NameEn;
                    d.Code = t.Code;
                    d.Status = t.Status;
                    db.TbemployeeCatagories.Add(d);
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
                    var d = (from c in db.TbemployeeCatagories where c.Id == id select c).FirstOrDefault();
                    d.Status = "DELETED";
                    db.SaveChanges();

                    var e = (from c in db.TbemployeeClassifications where c.EmployeeCategory == id select c).ToList();
                    e.ForEach(e => e.EmployeeCategory = "EGA");
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

        public TbemployeeCatagory Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeCatagories where  c.Id == id select c).FirstOrDefault();
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

        public IEnumerable<TbemployeeCatagory> GetList()
        {
            var list = new List<TbemployeeCatagory>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.TbemployeeCatagories where c.Status != "DELETED" select c).ToList();
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

        public string Update(string id, TbemployeeCatagory t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d =(from c in db.TbemployeeCatagories where c.Id == id select c).FirstOrDefault();
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
