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
    public class RoleServices : IRoleServices
    {
        private readonly ILog log = LogManager.GetLogger(typeof(RoleServices));
        public IConfiguration Configuration { get; }
        public RoleServices(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public object Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbroles where c.Id == id select c).FirstOrDefault();
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
            var list = new List<Tbrole>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.Tbroles select c).ToList();
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
    }
}
