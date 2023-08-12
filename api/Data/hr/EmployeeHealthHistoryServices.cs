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
    public class EmployeeHealthHistoryServices : IEmployeeHealthHistoryServices
    {
        public EmployeeHealthHistoryServices( IConfiguration configuration)
        {
            
            this.Configuration = configuration;
        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(EmployeeHealthHistoryServices));

        public IConfiguration Configuration { get; }

        public IEnumerable<TbemployeeHealthHistory> CreateOnce(string employeeId, TbemployeeHealthHistory[] healthHistories)
        {
            var list = new List<TbemployeeHealthHistory>();
            try
            {
                if (healthHistories != null)
                {
                    if (healthHistories.Length > 0)
                    {
                        foreach (var item in healthHistories)
                        {
                            item.Employee = employeeId;
                            this.Create(item);
                        }
                    }
                }

                return this.GetList(employeeId);
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return list;
            }
        }

        public TbemployeeHealthHistory Create(TbemployeeHealthHistory t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    //string ID = NumberConstrol.GetNextNumber("EHS");

                    var rawmaxid = db.TbemployeeHealthHistories.Max(m => m.Id);
                    var maxid = int.Parse(rawmaxid.Replace('E', ' ').Replace('H', ' ').Replace('S', ' '));
                    string id = NumberConstrol.GetNextNumber("EHS");
                    var numid = int.Parse(id.Replace('E', ' ').Replace('H', ' ').Replace('S', ' '));
                    if (numid <= maxid)
                    {
                        id = NumberConstrol.SetNewMaxNumber("EHS", maxid);
                    }

                    var d = new TbemployeeHealthHistory();
                    d.Id = id;
                    d.Employee = t.Employee;
                    d.Location = t.Location;
                    d.Description = t.Description;
                    d.Status = t.Status;
                    d.FilePath = t.FilePath;
                    d.DateLog = t.DateLog;
                    db.TbemployeeHealthHistories.Add(d);
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

        public string Delete(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeHealthHistories where c.Id == id select c).FirstOrDefault();
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

        public TbemployeeHealthHistory Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeHealthHistories where c.Id == id select c).FirstOrDefault();
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

        public IEnumerable<TbemployeeHealthHistory> GetList(string emp_id)
        {
            var list = new List<TbemployeeHealthHistory>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.TbemployeeHealthHistories where c.Employee == emp_id select c).ToList();
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

        public string Update(string id, TbemployeeHealthHistory t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeHealthHistories where c.Id == id select c).FirstOrDefault();
                    if (d == null) throw new Exception("DATA_NOT_FOUND");
                    d.Employee = t.Employee;
                    d.Location = t.Location;
                    d.Description = t.Description;
                    d.Status = t.Status;
                    d.FilePath = t.FilePath;
                    d.DateLog = t.DateLog;
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
