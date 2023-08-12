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
    public class IdentityTypeServices : IIdentityTypeServices
    {
        public IdentityTypeServices(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(IdentityTypeServices));

        public IConfiguration Configuration { get; }

        public TbidentityType Create(TbidentityType t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string id = NumberConstrol.GetNextNumber("IDT");
                    var d = new TbidentityType();
                    d.Id = id;
                    d.Name = t.Name;
                    d.NameEn = t.NameEn;
                    d.Code = t.Code;
                    d.Status = t.Status;
                    db.TbidentityTypes.Add(d);
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
                    var d = (from c in db.TbidentityTypes where c.Id == id select c).FirstOrDefault();
                    d.Status = "DELETED";
                    db.SaveChanges();
                    db.Dispose();
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return "SUCCESS";
            }
        }

        public TbidentityType Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbidentityTypes where c.Id == id select c).FirstOrDefault();
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

        public IEnumerable<TbidentityType> GetList()
        {
            var list = new List<TbidentityType>();

            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.TbidentityTypes where c.Status != "DELETED" select c).ToList();
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

        public string Update(string id, TbidentityType t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbidentityTypes where c.Id == id select c).FirstOrDefault();
                    d.Name = t.Name;
                    d.NameEn = t.NameEn;
                    d.Code = t.Code;
                    d.Status = t.Status;
                    db.SaveChanges();
                    db.Dispose();
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return "SUCCESS";
            }

        }
    }
}
