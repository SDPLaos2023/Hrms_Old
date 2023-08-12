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
    public class EmployeeContractServices : IEmployeeContractServices
    {
        public EmployeeContractServices( IConfiguration configuration)
        {
            
            this.Configuration = configuration;
        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(EmployeeContractServices));

        public IConfiguration Configuration { get; }


        public TbemployeeContract Create(TbemployeeContract t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    //string ID = NumberConstrol.GetNextNumber("ET");
                    var rawmaxid = db.TbemployeeContracts.Max(m => m.Id);
                    var maxid = int.Parse(rawmaxid.Replace('E', ' ').Replace('T', ' ') );
                    string id = NumberConstrol.GetNextNumber("ET");
                    var numid = int.Parse(id.Replace('E', ' ').Replace('T', ' ') );
                    if (numid <= maxid)
                    {
                        id = NumberConstrol.SetNewMaxNumber("ET", maxid);
                    } 

                    var d = new TbemployeeContract();
                    d.Id = id;
                    d.Employee = t.Employee;
                    d.ContractType = t.ContractType;
                    d.ContractStartAt = t.ContractStartAt;
                    d.ContractStopAt = t.ContractStopAt;
                    d.ContractNo= t.ContractNo;
                    d.CreatedAt = t.CreatedAt;
                    d.CreatedBy = t.CreatedBy;
                    d.UpdatedAt = t.UpdatedAt;
                    d.UpdatedBy = t.UpdatedBy;
                    db.TbemployeeContracts.Add(d);
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

        public TbemployeeContract Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeContracts where c.Id == id select c).FirstOrDefault();                    
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

        public TbemployeeContract GetContract(string emp_id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeContracts where c.Employee == emp_id select c).FirstOrDefault();
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

        public string Update(string id, TbemployeeContract t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeContracts where c.Id == id select c).FirstOrDefault();
                    if (d == null) throw new Exception("DATA_NOT_FOUND");
                        d.Employee = t.Employee;
                        d.ContractType = t.ContractType;
                        d.ContractStartAt = t.ContractStartAt;
                        d.ContractStopAt = t.ContractStopAt;
                        d.ContractNo = t.ContractNo;
                        d.UpdatedAt = t.UpdatedAt;
                        d.UpdatedBy = t.UpdatedBy;
                    
                    db.SaveChanges();
                    db.Dispose();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "DATA_NOT_FOUND") {
                    this.Create(t);
                }
                this._logger.Error(ex.Message);
                return "UNSUCCESS";
            }
            return "SUCCESS";
        }
    }
}
