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
    public class DepartmentServices : IDepartmentServices
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(DepartmentServices));

        public IConfiguration Configuration { get; }
        public DepartmentServices(IConfiguration configuration)
        {
            
            this.Configuration = configuration;
        }
        public string Create(Tbdepartment dept)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string ID = NumberConstrol.GetNextNumber("D");
                    var d = new Tbdepartment() {
                        Id = ID,
                        Name= dept.Name,
                        NameEn= dept.NameEn,
                        Code= dept.Code,
                        Status= dept.Status,
                        Company= dept.Company,
                    };
                    db.Tbdepartments.Add(d);
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

        public Tbdepartment GetDepartment(string ID)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbdepartments where c.Id == ID select c).FirstOrDefault();
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

        public IEnumerable<Tbdepartment> GetList()
        {
            var list = new List<Tbdepartment>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.Tbdepartments where c.Status != "DELETED" select c).ToList();
                    db.Dispose();
                    return list;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
            }
            return list;

        }

        public string Update(string ID, Tbdepartment dept)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbdepartments where c.Id == ID select c).FirstOrDefault();
                    d.Name = dept.Name;
                    d.NameEn = dept.NameEn;
                    d.Company = dept.Company;
                    d.Status = dept.Status;
                    d.Parent = dept.Parent;
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

        public string Delete(string ID)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbdepartments where c.Id == ID select c).FirstOrDefault();
                    d.Status = "DELETED";
                    db.SaveChanges();

                    var e = (from c in db.TbemployeeEmployments where c.Department == ID select c).ToList();
                    e.ForEach(e => e.Department = "D");
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
