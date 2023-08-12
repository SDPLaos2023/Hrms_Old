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
    public class PositionServices : IPositionServices
    {
        public PositionServices(IConfiguration configuration)
        {
            
            this.Configuration = configuration;

        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(PositionServices));

        public IConfiguration Configuration { get; }
        public string Create(Tbpostion posi)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string ID = NumberConstrol.GetNextNumber("P");
                    var d = new Tbpostion();
                    d.Id = ID;
                    d.Name = posi.Name;
                    d.NameEn = posi.NameEn;
                    d.Code = posi.Code;
                    d.Status = posi.Status;
                    db.Tbpostions.Add(d);
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
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbpostions where c.Id == ID select c).FirstOrDefault();
                    d.Status = "DELETED";
                    db.SaveChanges();

                    var e = (from c in db.TbemployeeEmployments where c.Position == ID select c).ToList();
                    e.ForEach(e => e.Position = "P");
                    db.SaveChanges();
                    db.Dispose();
                }
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return "UNSUCCESS";
            }
        }

        public IEnumerable<Tbpostion> GetList()
        {
            var list = new List<Tbpostion>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.Tbpostions where c.Status !="DELETED" select c).ToList();
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

        public Tbpostion GetPosition(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbpostions where c.Id == id select c).FirstOrDefault();
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

        public string Update(string ID, Tbpostion posi)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbpostions where c.Id == ID select c).FirstOrDefault();
                    d.Name = posi.Name;
                    d.NameEn = posi.NameEn;
                    d.Code = posi.Code;
                    d.Status = posi.Status;
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
