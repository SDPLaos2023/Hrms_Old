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
    public class EmployeeSalaryServices : IEmployeeSalaryServices
    {
        public EmployeeSalaryServices(IConfiguration configuration)
        {
            
            this.Configuration = configuration;
        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(EmployeeSalaryServices));

        public IConfiguration Configuration { get; }
        public TbemployeeSalarySetting Create(TbemployeeSalarySetting t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    //string ID = NumberConstrol.GetNextNumber("ES");
                    var rawmaxid = db.TbemployeeSalarySettings.Max(m => m.Id);
                    var maxid = int.Parse(rawmaxid.Replace('E', ' ').Replace('S', ' '));
                    string id = NumberConstrol.GetNextNumber("ES");
                    var numid = int.Parse(id.Replace('E', ' ').Replace('S', ' '));
                    if (numid <= maxid)
                    {
                        id = NumberConstrol.SetNewMaxNumber("ES", maxid);
                    }
                    var d = new TbemployeeSalarySetting();
                    d.Id = id;
                    d.Employee = t.Employee;
                    d.BaseSalary = t.BaseSalary;
                    d.SalaryType = t.SalaryType;
                    d.SalaryPayType = t.SalaryPayType;
                    d.Bank = t.Bank;
                    d.BankAccount = t.BankAccount;
                    d.CreatedAt = t.CreatedAt;
                    d.CreatedBy = t.CreatedBy;
                    d.UpdatedAt = t.UpdatedAt;
                    d.UpdatedBy = t.UpdatedBy;
                    db.TbemployeeSalarySettings.Add(d);
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

        public TbemployeeSalarySetting Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeSalarySettings where c.Id == id select c).FirstOrDefault();
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

        public TbemployeeSalarySetting GetSalarySetting(string emp_id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeSalarySettings where c.Employee == emp_id select c).FirstOrDefault();
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

        public string Update(string id, TbemployeeSalarySetting t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    //if (t.Employee.StartsWith("TEMP"))
                    //    return;

                    var d = (from c in db.TbemployeeSalarySettings where c.Id == id select c).FirstOrDefault();
                    if (d == null) throw new Exception("DATA_NOT_FOUND");
                    d.Employee = t.Employee;
                    d.BaseSalary = t.BaseSalary;
                    d.SalaryType = t.SalaryType;
                    d.SalaryPayType = t.SalaryPayType;
                    d.Bank = t.Bank;
                    d.BankAccount = t.BankAccount;
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
