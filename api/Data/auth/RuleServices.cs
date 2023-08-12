using hrm_api.Models;
using hrm_api.Services.Interfaces.auth;
using log4net;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Data.auth
{
    public class RuleServices : IRuleServices
    {
        private readonly ILog log = LogManager.GetLogger(typeof(RuleServices));
        public IConfiguration Configuration { get; }
        public RuleServices(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public object Create(Tbrule t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string id = NumberConstrol.GetNextNumber("RU");
                    var d = new Tbrule();
                    d.Id = id;
                    d.Name = t.Name;
                    d.Status = t.Status;
                    db.Tbrules.Add(d);
                    db.SaveChanges();
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

        public object Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbrules where c.Id == id select c).FirstOrDefault();
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

        public object GetList()
        {
            var list = new List<Tbrule>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.Tbrules select c).ToList();
                    db.Dispose();
                    return list;
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return list;
            }
        }

        public object Update(string id, Tbrule t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbrules where c.Id == id select c).FirstOrDefault();
                    d.Name = t.Name;
                    d.Status = t.Status;
                    db.SaveChanges();
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

        public object Delete(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var count = (from c in db.AuthUserRoles where c.Role == id select c).Count();
                    if (count > 0) {
                        return "NOT_ALLOW";
                    }

                    var d = (from c in db.Tbrules where c.Id == id select c).FirstOrDefault();
                    db.TbruleItems.RemoveRange(db.TbruleItems.Where(e => e.Rule == id).ToList());
                    db.Tbrules.Remove(d);
                    db.SaveChanges();
                    db.Dispose();
                    return "OK";
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return "ERROR";
            }
        }
    }
}
