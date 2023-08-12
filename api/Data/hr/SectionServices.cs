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
    public class SectionServices : ISectionServices
    {
        public SectionServices(IConfiguration configuration)
        {
            
            this.Configuration = configuration;

        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(SectionServices));

        public IConfiguration Configuration { get; }

        public string Create(Tbsection sect)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string ID = NumberConstrol.GetNextNumber("S");
                    var d = new Tbsection();
                    d.Id = ID;
                    d.Name = sect.Name;
                    d.NameEn = sect.NameEn;
                    d.Code = sect.Code;
                    d.Status = sect.Status;
                    db.Tbsections.Add(d);
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

        public string Delete(string ID)
        {
            try
            {
                using (var db  = new hrm_projectContext())
                {
                    var d = (from c in db.Tbsections where c.Id == ID select c).FirstOrDefault();
                    d.Status = "DELETED";
                    db.SaveChanges();

                    var e = (from c in db.TbemployeeEmployments where c.Section == ID select c).ToList();
                    e.ForEach(e => e.Section = "S");
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

        public IEnumerable<Tbsection> GetList()
        {
            var list = new List<Tbsection>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.Tbsections where c.Status != "DELETED" select c).ToList();
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

        public Tbsection GetSection(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbsections where c.Id == id select c).FirstOrDefault();
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

        public string Update(string ID, Tbsection sect)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbsections where c.Id == ID select c).FirstOrDefault();
                    d.Name = sect.Name;
                    d.NameEn = sect.NameEn;
                    d.Code = sect.Code;
                    d.Status = sect.Status;
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
