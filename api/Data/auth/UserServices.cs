using hrm_api.Data.hr;
using hrm_api.Models;
using hrm_api.Models.auth;
using hrm_api.Services;
using hrm_api.Services.Interfaces.auth;
using log4net;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Data.auth
{
    public class UserServices : IUserServices
    {
        private readonly ILog log = LogManager.GetLogger(typeof(UserServices));
        public IConfiguration Configuration { get; }
        public UserServices(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public object ChangePassword(string id, AuthUser t)
        {
            try
            {
                var decrData = EncrDecrServices.Decrypt(t.Password);
                using (var db = new hrm_projectContext())
                {
                    var passwordEncrypted = new JwtAuthenticationManager(this.Configuration).Encrypt(decrData);
                    var user = (from c in db.AuthUsers where c.Id == t.Id select c).FirstOrDefault();
                    user.Password = passwordEncrypted;
                    db.SaveChanges();
                    db.Dispose();
                    return user;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return "NOK";
            }
        }

        public object Create(AuthUser t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string id = NumberConstrol.GetNextNumber("UE");
                    var clearPwd = EncrDecrServices.Decrypt(t.Password);
                    Console.WriteLine(clearPwd);
                    var d = new AuthUser();
                    d.Id = id;
                    d.Username = t.Username;
                    d.Password = EncrDecrServices.Encrypt(clearPwd);
                    d.Employee = t.Employee;
                    d.Status = t.Status;
                    d.Role = t.Role;
                    d.Rule = t.Rule == null ? "RU00003" : t.Rule;
                    d.IsChangePwd = t.IsChangePwd;
                    db.AuthUsers.Add(d);
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

        public object GetList()
        {
            var list = new List<AuthUser>();
            try
            {

                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.AuthUsers where c.Status !="DELETED" select c).OrderBy(x => x.Role).OrderBy(x => x.Username).ToList();

                    var xx = db.AuthUsers.Select(x => new AuthUser
                    {
                        Id = x.Id,
                        Username = x.Username,
                        Password = x.Password,
                        Employee = x.Employee,
                        Status = x.Status,
                        Role = x.Role,
                        Rule = x.Rule,
                        IsChangePwd = x.IsChangePwd,
                        EmployeeNavigation = new EmployeeServices(this.Configuration).Get(x.Employee),
                        AuthUserRoles = x.AuthUserRoles.ToList(),
                        AuthUserRules = x.AuthUserRules.ToList()
                    }).ToList();

                    var authList = (from c in db.AuthUsers
                                    where c.Status != "DELETED"
                                    select new UserAuthResponse
                                    {
                                        Id = c.Id,
                                        Username = c.Username,
                                        Status = c.Status,
                                        Role = db.Tbroles.Where(e => e.Id == c.Role).FirstOrDefault(),
                                        Rule = db.Tbrules.Where(e => e.Id == c.Rule).FirstOrDefault(),
                                        IsChangePwd = (bool)c.IsChangePwd,
                                        Employee = new EmployeeServices(this.Configuration).Get(c.Employee),
                                    }).ToList();

                    db.Dispose();
                    return authList;
                }
            }
            catch (Exception ex)
            {
                this.log.Error(ex.Message);
                return list;
            }
        }

        public object Update(string id, AuthUser t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.AuthUsers where c.Id == t.Id select c).FirstOrDefault();
                    d.Role = t.Role;
                    //d.Rule = t.Rule;
                    d.IsChangePwd = t.IsChangePwd;
                    d.Status = t.Status;
                    d.Employee = t.Employee;

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
                    var d = (from c in db.AuthUsers where c.Id == id select c).FirstOrDefault();
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
        public object GetNoPassword(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.AuthUsers where c.Id == id select c).FirstOrDefault();
                    d.Password = null;
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
                    var user = (from c in db.AuthUsers where c.Id == id select c).FirstOrDefault();
                    user.Status = "DELETED";
                    db.SaveChanges();
                    db.Dispose();
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return "UNSUCCESS";
            }
        }
    }
}
