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
    public class EmployeeFamilyContactServices : IEmployeeFamilyContactServices
    {
        public EmployeeFamilyContactServices(IConfiguration configuration)
        {
            
            this.Configuration = configuration;
        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(EmployeeFamilyContactServices));
        public IConfiguration Configuration { get; }

        public TbemployeeFamilyContact Create(TbemployeeFamilyContact t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    //string ID = NumberConstrol.GetNextNumber("EFC");

                    var rawmaxid = db.TbemployeeFamilyContacts.Max(m => m.Id);
                    var maxid = int.Parse(rawmaxid.Replace('E', ' ').Replace('F', ' ').Replace('C', ' '));
                    string id = NumberConstrol.GetNextNumber("EFC");
                    var numid = int.Parse(id.Replace('E', ' ').Replace('F', ' ').Replace('C', ' '));
                    if (numid <= maxid)
                    {
                        id = NumberConstrol.SetNewMaxNumber("EFC", maxid);
                    }


                    var d = new TbemployeeFamilyContact();
                    d.Id = id;
                    d.Employee = t.Employee;
                    d.FatherName = t.FatherName;
                    d.FatherDob = t.FatherDob;
                    d.FatherContactNumber = t.FatherContactNumber;
                    d.MotherName = t.MotherName;
                    d.MotherDob = t.MotherDob;
                    d.MotherContactNumber = t.MotherContactNumber;
                    d.SpouseName = t.SpouseName;
                    d.SpouseDob = t.SpouseDob;
                    d.SpouseContactNumber = t.SpouseContactNumber;
                    d.NoChildren = t.NoChildren;
                    d.NoDaughter = t.NoDaughter;
                    db.TbemployeeFamilyContacts.Add(d);
                    db.SaveChanges();
                    db.Dispose();
                    return this.GetById(id);
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return null;
            }
        }

        private TbemployeeFamilyContact GetById(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeFamilyContacts where c.Id == id select c).FirstOrDefault();
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

        public TbemployeeFamilyContact Get(string emp_id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeFamilyContacts where c.Employee == emp_id select c).FirstOrDefault();
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

        public string Update(string id, TbemployeeFamilyContact t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeFamilyContacts where c.Id == id select c).FirstOrDefault();
                    if (d == null) throw new Exception("DATA_NOT_FOUND");

                    d.Employee = t.Employee;
                    d.FatherName = t.FatherName;
                    d.FatherDob = t.FatherDob;
                    d.FatherContactNumber = t.FatherContactNumber;
                    d.MotherName = t.MotherName;
                    d.MotherDob = t.MotherDob;
                    d.MotherContactNumber = t.MotherContactNumber;
                    d.SpouseName = t.SpouseName;
                    d.SpouseDob = t.SpouseDob;
                    d.SpouseContactNumber = t.SpouseContactNumber;
                    d.NoChildren = t.NoChildren;
                    d.NoDaughter = t.NoDaughter;
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
