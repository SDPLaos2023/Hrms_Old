using hrm_api.Models;
using hrm_api.Services.Interfaces.hr;
using log4net;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Data.hr
{
    public class EmployeeAllowanceServices : IEmployeeAllowanceServices
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(EmployeeAllowanceServices));
        public IConfiguration Configuration { get; }
        public EmployeeAllowanceServices(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public TbemployeeAllowance Create(TbemployeeAllowance t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    //string id = NumberConstrol.GetNextNumber("EA");
                    var rawmaxid = db.TbemployeeAllowances.Max(m => m.Id);
                    var maxid = int.Parse(rawmaxid.Replace('E', ' ').Replace('A', ' '));
                    string id = NumberConstrol.GetNextNumber("EA");
                    var numid = int.Parse(id.Replace('E', ' ').Replace('A', ' '));
                    if (numid <= maxid)
                    {
                        id = NumberConstrol.SetNewMaxNumber("EA", maxid);
                    }

                    var d = new TbemployeeAllowance();
                    d.Id = id;
                    d.Employee = t.Employee;
                    d.Allowance = t.Allowance;
                    d.Rate = t.Rate;
                    d.Status = t.Status;
                    d.CreatedAt = t.CreatedAt;
                    d.CreatedBy = t.CreatedBy;
                    d.UpdatedAt = t.UpdatedAt;
                    d.UpdatedBy = t.UpdatedBy;
                    db.TbemployeeAllowances.Add(d);
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

        public IEnumerable<TbemployeeAllowance> CreateOnce(string employeeId, TbemployeeAllowance[] allowances)
        {
            var list = new List<TbemployeeAllowance>();
            try
            {
                if (allowances != null)
                {
                    if (allowances.Length > 0)
                    {
                        foreach (var id in allowances)
                        {
                            id.Employee = employeeId;
                            this.Create(id);
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

        public string Delete(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeAllowances where c.Id == id select c).FirstOrDefault();
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

        public TbemployeeAllowance Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeAllowances where c.Id == id select c).FirstOrDefault();
                    d = db.TbemployeeAllowances.Where(e => e.Id == id).Select(e => new TbemployeeAllowance {
                        Id = e.Id,
                        Employee = e.Employee,
                        Allowance = e.Allowance,
                        Rate = e.Rate,
                        Status = e.Status,
                        CreatedAt = e.CreatedAt,
                        CreatedBy = e.CreatedBy,
                        UpdatedAt = e.UpdatedAt,
                        UpdatedBy = e.UpdatedBy,
                        AllowanceNavigation = new AllowanceServices(this.Configuration).Get(e.Allowance)

                    }).FirstOrDefault();

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

        public IEnumerable<TbemployeeAllowance> GetList(string employeeId)
        {
            var list = new List<TbemployeeAllowance>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = db.TbemployeeAllowances.Where(e => e.Employee == employeeId && e.Status !="DELETED").Select(e => new TbemployeeAllowance
                    {
                        Id = e.Id,
                        Employee = e.Employee,
                        Allowance = e.Allowance,
                        Rate = e.Rate,
                        Status = e.Status,
                        CreatedAt = e.CreatedAt,
                        CreatedBy = e.CreatedBy,
                        UpdatedAt = e.UpdatedAt,
                        UpdatedBy = e.UpdatedBy,
                        AllowanceNavigation = db.Tballowances.Where(a => a.Id == e.Allowance).FirstOrDefault()
                    }).ToList();
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

        public string Update(string id, TbemployeeAllowance t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeAllowances where c.Id == id select c).FirstOrDefault();
                    if (d == null) throw new Exception("DATA_NOT_FOUND");
                    d.Employee = t.Employee;
                    d.Allowance = t.Allowance;
                    d.Rate = t.Rate;
                    d.Status = t.Status;
                    d.UpdatedAt = t.UpdatedAt;
                    d.UpdatedBy = t.UpdatedBy;
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
