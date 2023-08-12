using hrm_api.Models;
using hrm_api.Services.Interfaces;
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
    public class EmployeeContactServices : IEmployeeContactServices
    {

        private readonly ILog _logger = LogManager.GetLogger(typeof(EmployeeContactServices));
        public IConfiguration Configuration { get; }

        public EmployeeContactServices(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }


        public TbemployeeContact Create(TbemployeeContact t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var rawmaxid = db.TbemployeeContacts.Max(m => m.Id);
                    var maxid = int.Parse(rawmaxid.Replace('E', ' ').Replace('C', ' '));
                    string id = NumberConstrol.GetNextNumber("EC");
                    var numid = int.Parse(id.Replace('E', ' ').Replace('C', ' '));
                    if (numid <= maxid)
                    {
                        id = NumberConstrol.SetNewMaxNumber("EC", maxid);
                    }


                    //string ID = NumberConstrol.GetNextNumber("EC");
                    var d = new TbemployeeContact();
                    d.Id = id;
                    d.Employee = t.Employee;
                    d.Mobile = t.Mobile;
                    d.Home = t.Home;
                    d.Wa = t.Wa;
                    d.Line = t.Line;
                    d.Wechat = t.Wechat;
                    d.Facebook = t.Facebook;
                    d.Twitter = t.Twitter;
                    d.Skype = t.Skype;
                    d.ContactPerson = t.ContactPerson;
                    d.ContactNumber = t.ContactNumber;
                    d.ContactRelation = t.ContactRelation;
                    d.CreatedAt = t.CreatedAt;
                    d.CreatedBy = t.CreatedBy;
                    d.UpdatedAt = t.UpdatedAt;
                    d.UpdatedBy = t.UpdatedBy;
                    db.TbemployeeContacts.Add(d);
                    db.SaveChanges();
                    return this.GetById(id);
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return null;
            }
        }        

        public TbemployeeContact Get(string emp_id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeContacts where c.Employee == emp_id select c).FirstOrDefault();
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

        public TbemployeeContact GetById(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeContacts where c.Id == id select c).FirstOrDefault();
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

        public string Update(string id, TbemployeeContact t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeContacts where c.Id == id select c).FirstOrDefault();
                    if (d == null) throw new Exception("DATA_NOT_FOUND");
                    d.Employee = t.Employee;
                    d.Mobile = t.Mobile;
                    d.Home = t.Home;
                    d.Wa = t.Wa;
                    d.Line = t.Line;
                    d.Wechat = t.Wechat;
                    d.Facebook = t.Facebook;
                    d.Twitter = t.Twitter;
                    d.Skype = t.Skype;
                    d.ContactPerson = t.ContactPerson;
                    d.ContactNumber = t.ContactNumber;
                    d.ContactRelation = t.ContactRelation;
                    d.UpdatedAt = t.UpdatedAt;
                    d.UpdatedBy = t.UpdatedBy;
                    db.SaveChanges();
                    db.Dispose();
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "DATA_NOT_FOUND")
                {
                    this.Create(t);
                }
                this._logger.Error(ex.Message);
                return "UNSUCCESS";
            }
        }
    }
}
