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
    public class EmployeeProbationServices : IEmployeeProbationServices
    {
        public EmployeeProbationServices(IConfiguration configuration)
        {
            
            this.Configuration = configuration;
        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(EmployeeProbationServices));

        public IConfiguration Configuration { get; }


        public TbemployeeProbation Create(TbemployeeProbation t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    //string ID = NumberConstrol.GetNextNumber("EB");
                    var rawmaxid = db.TbemployeeProbations.Max(m => m.Id);
                    var maxid = int.Parse(rawmaxid.Replace('E', ' ').Replace('B', ' '));
                    string id = NumberConstrol.GetNextNumber("EB");
                    var numid = int.Parse(id.Replace('E', ' ').Replace('B', ' '));
                    if (numid <= maxid)
                    {
                        id = NumberConstrol.SetNewMaxNumber("EB", maxid);
                    }

                    var d = new TbemployeeProbation();
                    d.Id = id;
                    d.Employee = t.Employee;
                    d.ContractStartAt = t.ContractStartAt;
                    d.ContractStopAt = t.ContractStopAt;
                    d.CreatedAt = t.CreatedAt;
                    d.CreatedBy = t.CreatedBy;
                    d.UpdatedAt = t.UpdatedAt;
                    d.UpdatedBy = t.UpdatedBy;
                    db.TbemployeeProbations.Add(d);
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

        public TbemployeeProbation Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeProbations where c.Id == id select c).FirstOrDefault();
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

        public TbemployeeProbation GetProbation(string emp_id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeProbations where c.Employee == emp_id select c).FirstOrDefault();
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

        public string Update(string id, TbemployeeProbation t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeProbations where c.Id == id select c).FirstOrDefault();
                    if (d == null) throw new Exception("DATA_NOT_FOUND");

                    d.Employee = t.Employee;
                    d.ContractStartAt = t.ContractStartAt;
                    d.ContractStopAt = t.ContractStopAt;
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
