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
    public class PageMasterServices : IPageMasterServices
    {
        private readonly ILog log = LogManager.GetLogger(typeof(PageMasterServices));
        public IConfiguration Configuration { get; }
        public PageMasterServices(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public object GetList()
        {
            var list = new List<TbpageMaster>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.TbpageMasters select c).ToList();
                    
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

        public object GetList(string pageGroup)
        {
            var list = new List<TbpageMaster>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.TbpageMasters where c.PageGroup == pageGroup select c).ToList();
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
