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
    public class EmployeeClassificationServices : IEmployeeClassificationServices
    {
        public EmployeeClassificationServices( IConfiguration configuration)
        {
            
            this.Configuration = configuration;
        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(EmployeeClassificationServices));

        public IConfiguration Configuration { get; }

        public TbemployeeClassification Create(TbemployeeClassification t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    //string ID = NumberConstrol.GetNextNumber("ECF");

                    var rawmaxid = db.TbemployeeClassifications.Max(m => m.Id);
                    var maxid = int.Parse(rawmaxid.Replace('E', ' ').Replace('C', ' ').Replace('F', ' '));
                    string id = NumberConstrol.GetNextNumber("ECF");
                    var numid = int.Parse(id.Replace('E', ' ').Replace('C', ' ').Replace('F', ' '));
                    if (numid <= maxid)
                    {
                        id = NumberConstrol.SetNewMaxNumber("ECF", maxid);
                    } 

                    var d = new TbemployeeClassification();
                    d.Id = id;
                    d.Employee = t.Employee;
                    d.EmployeeType = t.EmployeeType;
                    d.EmployeeGroup = t.EmployeeGroup;
                    d.EmployeeCategory = t.EmployeeCategory;
                    d.EmployeeLevel = t.EmployeeLevel;
                    d.EmployeeWorkingType = t.EmployeeWorkingType;
                    d.CreatedAt = t.CreatedAt;
                    d.CreatedBy = t.CreatedBy;
                    d.UpdatedAt = t.UpdatedAt;
                    d.UpdatedBy = t.UpdatedBy;
                    db.TbemployeeClassifications.Add(d);
                    db.SaveChanges();
                    db.Dispose();
                    return this.Get(id);
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return null;
            }
        }

        public TbemployeeClassification Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeClassifications where c.Id == id select c).FirstOrDefault();
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

        public TbemployeeClassification GetClassification(string emp_id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeClassifications where c.Employee == emp_id select c).FirstOrDefault();
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

        public string Update(string id, TbemployeeClassification t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeClassifications where c.Id == id select c).FirstOrDefault();
                    if (d == null) throw new Exception("DATA_NOT_FOUND");
                    d.Employee = t.Employee;
                    d.EmployeeType = t.EmployeeType;
                    d.EmployeeGroup = t.EmployeeGroup;
                    d.EmployeeCategory = t.EmployeeCategory;
                    d.EmployeeLevel = t.EmployeeLevel;
                    d.EmployeeWorkingType = t.EmployeeWorkingType;
                    d.CreatedAt = t.CreatedAt;
                    d.CreatedBy = t.CreatedBy;
                    d.UpdatedAt = t.UpdatedAt;
                    d.UpdatedBy = t.UpdatedBy;
                    db.SaveChanges();
                    db.Dispose();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "DATA_NOT_FOUND")
                {
                    this.Create(t);
                }
                this._logger.Error(ex.Message);
                return "UNSUCCESS";
            }
            return "SUCCESS";
        }
    }
}
