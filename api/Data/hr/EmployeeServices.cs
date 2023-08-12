using hrm_api.Models;
using hrm_api.Models.hr;
using hrm_api.Models.users;
using hrm_api.Services.Interfaces.hr;
using log4net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Data.hr
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly ILog log = LogManager.GetLogger(typeof(EmployeeServices));
        public EmployeeServices(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public EmployeeServices()
        {

        }

        public IConfiguration Configuration { get; }

        public Tbemployee Create(Tbemployee t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var rawmaxid = db.Tbemployees.Max(m => m.Id);
                    var maxid =int.Parse( rawmaxid.Replace('E',' ')); 
                    string id = NumberConstrol.GetNextNumber("E");
                    var numid  =int.Parse(id.Replace('E',' '));
                    if (numid <= maxid) {
                        id = NumberConstrol.SetNewMaxNumber("E",maxid);
                    }

                    var d = new Tbemployee();
                    d.Id = id;
                    d.Code = t.Code;
                    d.Name = t.Name;
                    d.NameEn = t.NameEn;
                    d.Dob = t.Dob;
                    d.Gender = t.Gender;
                    d.BloodGroup = t.BloodGroup;
                    d.Nationality = t.Nationality;
                    d.Race = t.Race;
                    d.IdCard = t.IdCard;
                    d.IdCardExpiryDate = t.IdCardExpiryDate;
                    d.IdCardIssuedBy = t.IdCardIssuedBy;
                    d.PassportNo = t.PassportNo;
                    d.PassportExpiryDate = t.PassportExpiryDate;
                    d.PassportIssuedBy = t.PassportIssuedBy;
                    d.Address = t.Address;
                    d.Province = t.Province;
                    d.District = t.District;
                    d.Country = t.Country;
                    d.Status = t.Status;
                    d.MaritalStatus = t.MaritalStatus;
                    d.CreatedBy = t.CreatedBy;
                    d.CreatedAt = t.CreatedAt; //DateTime.Now;
                    d.UpdatedBy = t.UpdatedBy;
                    d.UpdatedAt = t.UpdatedAt;//DateTime.Now;
                    db.Tbemployees.Add(d);
                    db.SaveChanges();
                    db.Dispose();
                    return this.Get(id);
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return null;
            }
        }

        public Tbemployee CreateOnce(CreateEmployeeRequest t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    Tbemployee emp = this.Create(t.employee);

                    if (t.contact != null)
                    {
                        t.contact.Employee = emp.Id;
                        var contact = new EmployeeContactServices(this.Configuration);
                        var rs = contact.Create(t.contact);
                    }

                    if (t.familyContact != null)
                    {
                        t.familyContact.Employee = emp.Id;
                        var contact = new EmployeeFamilyContactServices(this.Configuration);
                        var rs = contact.Create(t.familyContact);

                    }

                    if (t.contract != null)
                    {
                        t.contract.Employee = emp.Id;
                        var contract = new EmployeeContractServices(this.Configuration);
                        var rs = contract.Create(t.contract);

                    }

                    if (t.probationContract != null)
                    {
                        t.probationContract.Employee = emp.Id;
                        var contract = new EmployeeProbationServices(this.Configuration);
                        var rs = contract.Create(t.probationContract);

                    }

                    if (t.classification != null)
                    {
                        t.classification.Employee = emp.Id;
                        var classify = new EmployeeClassificationServices(this.Configuration);
                        var rs = classify.Create(t.classification);

                    }

                    if (t.employment != null)
                    {
                        t.employment.Employee = emp.Id;
                        var employment = new EmployeeEmploymentServices(this.Configuration);
                        var rs = employment.Create(t.employment);
                    }

                    if (t.salarySetting != null)
                    {
                        t.salarySetting.Employee = emp.Id;
                        var salarySetting = new EmployeeSalaryServices(this.Configuration);
                        var rs = salarySetting.Create(t.salarySetting);
                    }

                    if (t.leaveSetting != null)
                    {
                        t.leaveSetting.Employee = emp.Id;
                        var leaveSetting = new EmployeeLeaveSettingServices(this.Configuration);
                        var rs = leaveSetting.Create(t.leaveSetting);
                    }

                    if (t.insurance != null)
                    {
                        t.insurance.Employee = emp.Id;
                        var insurance = new EmployeeInsuranceServices(this.Configuration);
                        var rs = insurance.Create(t.insurance);
                    }

                    if (t.idCards.Length > 0)
                    {
                        var ids = new EmployeeIdentityServices(this.Configuration);
                        var rs = ids.CreateOnce(emp.Id, t.idCards);
                    }
                    if (t.educations.Length > 0)
                    {
                        var edu = new EmployeeEduHistoryServices(this.Configuration);
                        var rs = edu.CreateOnce(emp.Id, t.educations);
                    }

                    if (t.healthHistories.Length > 0)
                    {
                        var healthHistories = new EmployeeHealthHistoryServices(this.Configuration);
                        var rs = healthHistories.CreateOnce(emp.Id, t.healthHistories);
                    }

                    if (t.allowances.Length > 0)
                    {
                        var allowance = new EmployeeAllowanceServices(this.Configuration);
                        var rs = allowance.CreateOnce(emp.Id, t.allowances);
                    }

                    db.Dispose();
                    return this.Get(emp.Id);
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return null;
            }
        }

        public string Delete(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbemployees where c.Id == id select c).FirstOrDefault();
                    d.Status = "DELETED";
                    db.SaveChanges();
                    db.Dispose();
                    return this.Update(id, d);
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return "UNSUCCESS";
            }
        }

        public Tbemployee Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var eduHis = new EmployeeEduHistoryServices(this.Configuration);
                    var empAllowance = new EmployeeAllowanceServices(this.Configuration);
                    var d = db.Tbemployees.Where(e => e.Id == id)
                        .Select(e => new Tbemployee
                        {
                            Id = e.Id,
                            Code = e.Code,
                            Name = e.Name,
                            NameEn = e.NameEn,
                            Dob = e.Dob,
                            Gender = e.Gender,
                            BloodGroup = e.BloodGroup,
                            Nationality = e.Nationality,//
                            Race = e.Race,//
                            Address = e.Address,
                            Province = e.Province,//
                            District = e.District,//
                            Country = e.Country,//
                            Status = e.Status,//
                            MaritalStatus = e.MaritalStatus,
                            CreatedBy = e.CreatedBy,
                            CreatedAt = e.CreatedAt,
                            UpdatedBy = e.UpdatedBy,
                            UpdatedAt = e.UpdatedAt,
                            Avatar = e.Avatar,

                            TbemployeeAllowances = empAllowance.GetList(e.Id).ToList(),
                            TbemployeeClassifications = e.TbemployeeClassifications.ToList(),
                            TbemployeeContacts = e.TbemployeeContacts.ToList(),
                            TbemployeeContracts = e.TbemployeeContracts.ToList(),
                            TbemployeeEducationHistories = eduHis.GetList(e.Id).ToList(),
                            TbemployeeEmployments = e.TbemployeeEmployments.ToList(),
                            TbemployeeFamilyContacts = e.TbemployeeFamilyContacts.ToList(),
                            TbemployeeHealthHistories = e.TbemployeeHealthHistories.ToList(),
                            TbemployeeIdentities = e.TbemployeeIdentities.ToList(),
                            TbemployeeInsurances = e.TbemployeeInsurances.ToList(),
                            TbemployeeLeaveSettings = e.TbemployeeLeaveSettings.ToList(),
                            TbemployeeProbations = e.TbemployeeProbations.ToList(),
                            TbemployeeSalaryHistories = e.TbemployeeSalaryHistories.ToList(),
                            TbemployeeSalarySettings = e.TbemployeeSalarySettings.ToList(),
                            TbemployeeTransactions = e.TbemployeeTransactions.ToList(),

                        }).FirstOrDefault();
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

        public object GetEmployeeName(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var e = (from t in db.Tbemployees
                             where t.Id == id
                             select new Tbemployee
                             {
                                 NameEn = t.NameEn,
                                 Name = t.Name
                             }).FirstOrDefault();

                    db.Dispose();
                    return e;
                }
            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
                return null;
            }
        }

        public IEnumerable<Tbemployee> GetList()
        {
            var list = new List<Tbemployee>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.Tbemployees where c.Status != "DELETED" && c.Id != "admin" select c).ToList();
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

        public IEnumerable<EmployeeNoneUserResponse> GetListNoneUser()
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

                    var employees = db.Tbemployees.Where(e => e.Status != "DELETED");
                    employees = employees.Where(e => !db.AuthUsers
                             .Select(u => u.Employee)
                             .Contains(e.Id)
                         );//.ToList();
                    //log.Info(JsonConvert.SerializeObject(employees.ToList()));

                    //.Select(e => new Tbemployee() {
                    //    Id = e.Id,
                    //    Name = e.Name,
                    //    TbemployeeEmployments = e.TbemployeeEmployments.ToList()
                    //})

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

        public string Update(string id, Tbemployee t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {

                    var d = (from c in db.Tbemployees where c.Id == id select c).FirstOrDefault();
                    d.Code = t.Code;
                    d.Name = t.Name;
                    d.NameEn = t.NameEn;
                    d.Dob = t.Dob;
                    d.Gender = t.Gender;
                    d.BloodGroup = t.BloodGroup;
                    d.Nationality = t.Nationality;
                    d.Race = t.Race;
                    d.IdCard = t.IdCard;
                    d.IdCardExpiryDate = t.IdCardExpiryDate;
                    d.IdCardIssuedBy = t.IdCardIssuedBy;
                    d.PassportNo = t.PassportNo;
                    d.PassportExpiryDate = t.PassportExpiryDate;
                    d.PassportIssuedBy = t.PassportIssuedBy;
                    d.Address = t.Address;
                    d.Province = t.Province;
                    d.District = t.District;
                    d.Country = t.Country;
                    d.Status = t.Status;
                    d.MaritalStatus = t.MaritalStatus;
                    d.UpdatedBy = t.UpdatedBy;
                    d.UpdatedAt = t.UpdatedAt;
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

        public string UpdateOnce(string id, CreateEmployeeRequest t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string resp = this.Update(id, t.employee);

                    if (t.contact != null)
                    {

                        var contact = new EmployeeContactServices(this.Configuration);
                        t.contact.Employee = t.employee.Id;
                        var rs = contact.Update(t.contact.Id, t.contact);
                    }

                    if (t.familyContact != null)
                    {
                        var contact = new EmployeeFamilyContactServices(this.Configuration);
                        t.familyContact.Employee = t.employee.Id;
                        var rs = contact.Update(t.familyContact.Id, t.familyContact);

                    }

                    if (t.contract != null)
                    {
                        var contract = new EmployeeContractServices(this.Configuration);
                        t.contract.Employee = t.employee.Id;
                        var rs = contract.Update(t.contract.Id, t.contract);

                    }

                    if (t.probationContract != null)
                    {
                        var contract = new EmployeeProbationServices(this.Configuration);
                        t.probationContract.Employee = t.employee.Id;
                        var rs = contract.Update(t.probationContract.Id, t.probationContract);

                    }

                    if (t.classification != null)
                    {
                        var classify = new EmployeeClassificationServices(this.Configuration);
                        t.classification.Employee = t.employee.Id;
                        var rs = classify.Update(t.classification.Id, t.classification);

                    }

                    if (t.employment != null)
                    {
                        var employment = new EmployeeEmploymentServices(this.Configuration);
                        t.employment.Employee = t.employee.Id;
                        var rs = employment.Update(t.employment.Id, t.employment);
                    }

                    if (t.salarySetting != null)
                    {
                        var salarySetting = new EmployeeSalaryServices(this.Configuration);
                        t.salarySetting.Employee = t.employee.Id;
                        var rs = salarySetting.Update(t.salarySetting.Id, t.salarySetting);
                    }

                    if (t.leaveSetting != null)
                    {
                        var leaveSetting = new EmployeeLeaveSettingServices(this.Configuration);
                        t.leaveSetting.Employee = t.employee.Id;
                        var rs = leaveSetting.Update(t.leaveSetting.Id, t.leaveSetting);
                    }

                    if (t.insurance != null)
                    {
                        var insurance = new EmployeeInsuranceServices(this.Configuration);
                        t.insurance.Employee = t.employee.Id;
                        var rs = insurance.Update(t.insurance.Id, t.insurance);
                    }

                    db.Dispose();
                    return resp;
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return "UNSUCCESS";
            }
        }

        public object GetEmployeeDepartment(string department)
        {
            try
            {
                using (var db = new dbContext())
                {
                    var sp = db.SpGetEmployeeByDept.FromSqlRaw("CALL getemployeebydepartment({0})",
                   department).ToList();
                    db.Dispose();
                    return sp;
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return "UNSUCCESS";
            }
        }
    }
}
