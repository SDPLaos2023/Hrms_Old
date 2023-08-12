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
    public class DivisionServices : IDivisionServices
    {
        public DivisionServices( IConfiguration configuration)
        {
            
            this.Configuration = configuration;
        }

        private readonly ILog log = LogManager.GetLogger(typeof(DivisionServices));

        public IConfiguration Configuration { get; }

        public string Create(Tbdivision division)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string ID = NumberConstrol.GetNextNumber("DV");
                    var d = new Tbdivision();
                    d.Id = ID;
                    d.Name = division.Name;
                    d.NameEn = division.NameEn;
                    d.Code = division.Code;
                    d.Status = division.Status;
                    d.Company = division.Company;
                    db.Tbdivisions.Add(d);
                    db.SaveChanges();
                    db.Dispose();
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return "UNSUCCESS";
            }
        }

        public Tbdivision GetDivision(string ID)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbdivisions where c.Id == ID select c).FirstOrDefault();
                    db.Dispose();
                    return d;
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return null;
            }
        }

        public IEnumerable<Tbdivision> GetList()
        {
            var list = new List<Tbdivision>();

            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbdivisions where c.Status != "DELETED" select c).ToList();
                    db.Dispose();
                    return d;
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return list;
            }
        }

        public string Update(string ID, Tbdivision division)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbdivisions where c.Id == ID select c).FirstOrDefault();
                    d.Name = division.Name;
                    d.NameEn = division.NameEn;
                    d.Code = division.Code;
                    d.Status = division.Status;
                    d.Company = division.Company;
                    db.SaveChanges();
                    db.Dispose();
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return "UNSUCCESS";
            }
        }

        public string Delete(string id)
        {
            try
            {
                
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbdivisions where c.Id == id select c).FirstOrDefault();
                    d.Status = "DELETED";
                    db.SaveChanges();

                    var e = (from c in db.TbemployeeEmployments where c.Division == id select c).ToList();
                    e.ForEach(e => e.Division = "DV");

                    db.SaveChanges();
                    db.Dispose();
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return "UNSUCCESS";
            }


        }
    }
}
