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
    public class RuleItemsServices : IRuleItemServices
    {
        private readonly ILog log = LogManager.GetLogger(typeof(RuleItemsServices));
        public IConfiguration Configuration { get; }
        public RuleItemsServices(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public object Create(TbruleItem t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string id = NumberConstrol.GetNextNumber("RI");
                    var d = new TbruleItem();
                    d.Id = id;
                    d.Rule = t.Rule;
                    d.PageName = t.PageName;
                    d.Uri = t.Uri;
                    d.PageId = t.PageId;
                    db.TbruleItems.Add(d);
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
                    var d = (from c in db.TbruleItems where c.Id == id select c).FirstOrDefault();
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

        public object GetList(string rule_id)
        {
            var list = new List<TbruleItem>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = db.TbruleItems.Where(r=>r.Rule == rule_id).Select(e => new TbruleItem
                    {
                        Id = e.Id,
                        Rule = e.Rule,
                        PageName = e.PageName,
                        PageId = e.PageId,
                        Uri = e.Uri,
                        Page = db.TbpageMasters.Where(p => p.Id == e.PageId).FirstOrDefault()
                    }).ToList();
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

        public object GetList()
        {
            var list = new List<TbruleItem>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = db.TbruleItems.Select(e => new TbruleItem
                    {
                        Id = e.Id,
                        Rule = e.Rule,
                        PageName = e.PageName,
                        PageId = e.PageId,
                        Uri =e.Uri,
                        Page = db.TbpageMasters.Where(p => p.Id == e.PageId).FirstOrDefault()
                    }).ToList();
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

        public object Update(string id, TbruleItem t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbruleItems where c.Id == id select c).FirstOrDefault();
                    d.Rule = t.Rule;
                    d.PageName = t.PageName;
                    d.Uri = t.Uri;
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
                    var d = (from c in db.TbruleItems where c.Id == id select c).FirstOrDefault();
                    db.TbruleItems.Remove(d);
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

        public object AddRuleItem(string rule_id, int page_id)
        {
            try
            {
                var rs = new TbruleItem(); 
                using (var db = new hrm_projectContext())
                {
                    var count = (from c in db.TbruleItems where c.Rule == rule_id && c.PageId == page_id select c).Count();
                    if (count <= 0) {
                        var page = (from c in db.TbpageMasters where c.Id == page_id select c).FirstOrDefault();
                        var item = new TbruleItem
                        {
                            Rule = rule_id,
                            PageName = page.Name,
                            Uri = page.Uri,
                            PageId = page.Id
                        };
                       rs =(TbruleItem)this.Create(item);
                    }
                    db.Dispose();
                    return rs;
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return null;
            }
        }

        public object AddAllRuleItem(string rule_id)
        {
            try
            {
                var rs = new TbruleItem();
                using (var db = new hrm_projectContext())
                {

                    var toRemove = db.TbruleItems.Where(x => x.Id == rule_id).ToList();
                    var query = toRemove.RemoveAll(x => toRemove.Contains(x));
                    var pages = (from c in db.TbpageMasters select c).ToList();
                    pages.ForEach(element =>
                    {
                        var item = new TbruleItem
                        {
                            Rule = rule_id,
                            PageName = element.Name,
                            Uri = element.Uri,
                            PageId = element.Id
                        };
                        this.Create(item);
                    });

                    db.Dispose();
                    return this.GetList(rule_id);
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return new List<TbruleItem>();
            }
        }
    }
}
