using hrm_api.Models.hr;
using hrm_api.Services.Interfaces.hr;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;
using hrm_api.Models;
using log4net;

namespace hrm_api.Data.hr
{
    public class CompanyService : ICompanyService
    {
        public CompanyService(IConfiguration configuration)
        {
            
            this.Configuration = configuration;
        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(CompanyService));

        public IConfiguration Configuration { get; }

        public string Create(Tbcompany company)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string ID = NumberConstrol.GetNextNumber("CM");
                    company.Id = ID;
                    db.Tbcompanies.Add(company);
                    db.SaveChanges();
                    db.Dispose();
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
            }
            return "UNSUCCESS";
        }

        public Tbcompany GetCompany(string ID)
        {
            var com = new Tbcompany();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    com = (from c in db.Tbcompanies where c.Id == ID select c).FirstOrDefault();
                    db.Dispose();
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
            }
            return com;
        }

        public IEnumerable<Tbcompany> GetList()
        {
            var com = new List<Tbcompany>();

            try
            {
                using (var db = new hrm_projectContext())
                {
                    com = (from c in db.Tbcompanies where c.Status == "ACTIVE" select c).ToList<Tbcompany>();
                    db.Dispose();
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
            }
            return com;
        }

        public string Update(string ID, Tbcompany company)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var com = (from c in db.Tbcompanies where c.Id == ID select c).FirstOrDefault();
                    com.Name = company.Name;
                    com.NameEn = company.NameEn;
                    com.Code = company.Code;
                    com.Status = company.Status;
                    com.Homebranch = company.Homebranch;
                    com.Controller = company.Controller;
                    com.Address = company.Address;
                    db.SaveChanges();
                    db.Dispose();
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {

                this._logger.Error(ex.Message);
            }
            return "UNSUCCESS";


        }
    }
}
