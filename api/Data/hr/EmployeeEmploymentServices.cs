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
    public class EmployeeEmploymentServices : IEmployeeEmploymentServices
    {
        public EmployeeEmploymentServices( IConfiguration configuration)
        {
            
            this.Configuration = configuration;
        }
        public EmployeeEmploymentServices()
        {

        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(EmployeeEmploymentServices));

        public IConfiguration Configuration { get; }
        public TbemployeeEmployment Create(TbemployeeEmployment t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    //string ID = NumberConstrol.GetNextNumber("EM");
                    var rawmaxid = db.TbemployeeEmployments.Max(m => m.Id);
                    var maxid = int.Parse(rawmaxid.Replace('E', ' ').Replace('M', ' '));
                    string id = NumberConstrol.GetNextNumber("EM");
                    var numid = int.Parse(id.Replace('E', ' ').Replace('M', ' '));
                    if (numid <= maxid)
                    {
                        id = NumberConstrol.SetNewMaxNumber("EM", maxid);
                    }
                    var d = new TbemployeeEmployment();
                    d.Id = id;
                    d.Employee = t.Employee;
                    d.Position = t.Position;
                    d.Department = t.Department;
                    d.Section = t.Section;
                    d.Division = t.Division;
                    d.CreatedAt = t.CreatedAt;
                    d.CreatedBy = t.CreatedBy;
                    d.UpdatedAt = t.UpdatedAt;
                    d.UpdatedBy = t.UpdatedBy;
                    db.TbemployeeEmployments.Add(d);
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

        public TbemployeeEmployment Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeEmployments where c.Id == id select c).FirstOrDefault();
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

        public TbemployeeEmployment GetEmployment(string emp_id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeEmployments where c.Employee == emp_id select c).FirstOrDefault();
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

        public string Update(string id, TbemployeeEmployment t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeEmployments where c.Id == id select c).FirstOrDefault();
                    if (d == null) throw new Exception("DATA_NOT_FOUND");
                    d.Employee = t.Employee;
                    d.Position = t.Position;
                    d.Department = t.Department;
                    d.Section = t.Section;
                    d.Division = t.Division;
                    d.UpdatedAt = t.UpdatedAt;
                    d.UpdatedBy = t.UpdatedBy;
                    db.SaveChanges();
                    db.Dispose();
                    return "SUCCESS";
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
        }
    }
}
