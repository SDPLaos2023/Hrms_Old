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
    public class EmployeeTransactionServices : IEmployeeTransactionServices
    {
        public EmployeeTransactionServices(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(EmployeeTransactionServices));
        public IConfiguration Configuration { get; }
        public TbemployeeTransaction Create(TbemployeeTransaction t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string id = NumberConstrol.GetNextNumber("ETS");
                    var d = new TbemployeeTransaction();
                    d.Id = id;
                    d.Employee = t.Employee;
                    d.TransactionType = t.TransactionType;
                    d.EffectiveDate = t.EffectiveDate;
                    d.Description = t.Description;
                    d.CreatedAt = t.CreatedAt;
                    d.CreatedBy = t.CreatedBy;
                    d.UpdatedAt = t.UpdatedAt;
                    d.UpdatedBy = t.UpdatedBy;
                    db.TbemployeeTransactions.Add(d);
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
                    var d = (from c in db.TbemployeeTransactions where c.Id == id select c).FirstOrDefault();
                        
                    db.TbemployeeTransactions.Remove(d);
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

        public TbemployeeTransaction Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = db.TbemployeeTransactions.Where(e => e.Id == id).Select(e => new TbemployeeTransaction
                    {
                        Id = e.Id,
                        Employee = e.Employee,
                        TransactionType = e.TransactionType,
                        EffectiveDate = e.EffectiveDate,
                        Description = e.Description,
                        CreatedAt = e.CreatedAt,
                        CreatedBy = e.CreatedBy,
                        UpdatedAt = e.UpdatedAt,
                        UpdatedBy = e.UpdatedBy,
                        TransactionTypeNavigation = db.TbtransactionTypes.Where(t => t.Id == e.Id).FirstOrDefault()
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

        public IEnumerable<TbemployeeTransaction> GetList(string employeeId)
        {
            var list = new List<TbemployeeTransaction>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = db.TbemployeeTransactions.Where(e => e.Employee == employeeId).Select(e => new TbemployeeTransaction
                    {
                        Id = e.Id,
                        Employee = e.Employee,
                        TransactionType = e.TransactionType,
                        EffectiveDate = e.EffectiveDate,
                        Description = e.Description,
                        CreatedAt = e.CreatedAt,
                        CreatedBy = e.CreatedBy,
                        UpdatedAt = e.UpdatedAt,
                        UpdatedBy = e.UpdatedBy,
                        TransactionTypeNavigation = db.TbtransactionTypes.Where(t => t.Id == e.TransactionType).FirstOrDefault()
                    }).ToList();
                    db.Dispose();
                    return list;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return null;
            }
        }

        public string Update(string id, TbemployeeTransaction t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = db.TbemployeeTransactions.Where(e => e.Id == id).FirstOrDefault();
                    d.Employee = t.Employee;
                    d.TransactionType = t.TransactionType;
                    d.EffectiveDate = t.EffectiveDate;
                    d.Description = t.Description;
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
