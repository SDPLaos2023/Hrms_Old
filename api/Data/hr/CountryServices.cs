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
    public class CountryServices : ICountryServices
    {

        public CountryServices( IConfiguration configuration)
        {
            
            this.Configuration = configuration;

        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(CountryServices));

        public IConfiguration Configuration { get; }

        public string Create(Tbcountry country)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string ID = NumberConstrol.GetNextNumber("C");
                    var d = new Tbcountry();
                    d.Id = ID;
                    d.Name = country.Name;
                    d.NameEn = country.NameEn;
                    d.Code = country.Code;
                    d.Status = country.Status;
                    db.Tbcountries.Add(d);
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

        public string Delete(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbcountries where c.Id == id select c).FirstOrDefault();
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

        public Tbcountry Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbcountries where c.Id == id select c).FirstOrDefault();
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

        public IEnumerable<Tbcountry> GetList()
        {
            var list = new List<Tbcountry>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.Tbcountries where c.Status !="DELETED" select c).ToList();
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

        public string Update(string id, Tbcountry country)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbcountries where c.Id == id select c).FirstOrDefault();
                    d.Id = id;
                    d.Name = country.Name;
                    d.NameEn = country.NameEn;
                    d.Code = country.Code;
                    d.Status = country.Status;
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
