using hrm_api.Models;
using hrm_api.Models.users;
using hrm_api.Services.Interfaces.attendance;
using log4net;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace hrm_api.Data.attendance
{
    public class DeviceUsersServices : IDeviceUsersServices
    {

        private readonly ILog log = LogManager.GetLogger(typeof(DeviceUsersServices));
        public IConfiguration Configuration { get; }
        public DeviceUsersServices(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public string Create(Tbfpuser t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    //string id = NumberConstrol.GetNextNumber("FU");
                    var rawmaxid = db.Tbfpusers.Max(m => m.Id);
                    var maxid = int.Parse(rawmaxid.Replace('F', ' ').Replace('U', ' '));
                    string id = NumberConstrol.GetNextNumber("FU");
                    var numid = int.Parse(id.Replace('F', ' ').Replace('U', ' '));
                    if (numid <= maxid)
                    {
                        id = NumberConstrol.SetNewMaxNumber("FU", maxid);
                    }

                    var d = new Tbfpuser();
                    d.Id = id;
                    d.FpId = t.FpId;
                    d.FpUserId = t.FpUserId;
                    d.FpUserName = t.FpUserName;
                    d.FpRole = t.FpRole;
                    d.Employee = t.Employee;
                    db.Tbfpusers.Add(d);
                    db.SaveChanges();
                    this.addTempfingers(id);
                    db.Dispose();
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return null;
            }
        }

        private void addTempfingers(string id)
        {
            try
            {
                var fingerService = new DeviceUserFingerMappingServices(this.Configuration);
                for (int i = 0; i < 10; i++) {
                    var finger = new Tbfingerprintmapping { 
                        FingerIndex =i.ToString(),
                        FingerUserId = id,
                        FingerImg = null,
                        Status = null
                    };

                    fingerService.Create(finger);
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
            }
        }

        public string Delete(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbfpusers where c.Id == id select c).FirstOrDefault();
                    db.Tbfpusers.Remove(d);
                    db.SaveChanges();
                    db.Dispose();
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return null;
            }
        }

        public Tbfpuser Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbfpusers where c.Id == id select c).FirstOrDefault();
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

        public IEnumerable<Tbfpuser> GetList(string id)
        {
            var list = new List<Tbfpuser>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.Tbfpusers where c.FpId==id select c).ToList();
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

        public string Update(string id, Tbfpuser t)
        { 
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbfpusers where c.Id == id select c).FirstOrDefault();
                    d.FpId = t.FpId;
                    d.FpUserId = t.FpUserId;
                    d.FpUserName = t.FpUserName;
                    d.FpRole = t.FpRole;
                    d.Employee = t.Employee;
                    db.SaveChanges();
                    db.Dispose();
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return null;
            }
        }

        public string TransferUser(string newFpId,Tbfpuser d)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var fpUser = this.Get(d.Id);
                    var destinationFp = (from t in db.Tbfpusers where t.FpId == newFpId && t.FpUserId == fpUser.FpUserId select t).FirstOrDefault();
                    var resp = "SUCCESS"; 
                    if (destinationFp == null) {
                        resp = this.CreateTransfer(newFpId, d);
                    }
                    db.Dispose();
                    return resp;
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return "NOK";
            }
        }

        private string CreateTransfer(string newFpId, Tbfpuser t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string id = NumberConstrol.GetNextNumber("FU");
                    var d = new Tbfpuser();
                    d.Id = id;
                    d.FpId = newFpId;
                    d.FpUserId = t.FpUserId;
                    d.FpUserName = t.FpUserName;
                    d.FpRole = t.FpRole;
                    d.Employee = t.Employee;
                    db.Tbfpusers.Add(d);
                    db.SaveChanges();
                    this.addTempfingers(id);
                    db.Dispose();
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return null;
            }
        }

        

        

        public IEnumerable<EmployeeNoneUserResponse> GetListNoneUser(string fpId)
        {
            var list = new List<EmployeeNoneUserResponse>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    //list = (from c in db.Tbemployees where c.Status != "DELETED" && c.Id != "admin" select c).ToList();

                    var departments = db.Tbdepartments.Where(d => d.Status != "DELETED");//.ToList();
                    var divisions = db.Tbdivisions.Where(d => d.Status != "DELETED");//.ToList();
                    var employment = db.TbemployeeEmployments;//.ToList();

                    var fpusers = db.Tbfpusers.Where(f=>f.FpId == fpId);

                    var employees = db.Tbemployees.Where(e => e.Status != "DELETED");
                    employees = employees.Where(e => !fpusers
                             .Select(u => u.Employee)
                             .Contains(e.Id)
                         );//.ToList();

                    var joined = (from emp in employees
                                  join ee in employment on emp.Id equals ee.Employee
                                  join dept in departments on ee.Department equals dept.Id
                                  join divs in divisions on ee.Division equals divs.Id

                                  select new EmployeeNoneUserResponse()
                                  {
                                      id = emp.Id,
                                      employee_name = emp.Name,
                                      department_name = dept.Name,
                                      division_name = divs.Name
                                  }).ToList();

                    db.Dispose();
                    return joined;
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return list;
            }
        }

        public object GetFpUserId(string employee)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var fpUser = (from c in db.Tbfpusers where c.Employee == employee select c).FirstOrDefault();
                    db.Dispose();
                    return fpUser;
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return "NOK";
            }
        }
    }
}
