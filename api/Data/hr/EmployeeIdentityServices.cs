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
    public class EmployeeIdentityServices : IEmployeeIdentityServices
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(EmployeeIdentityServices));
        public IConfiguration Configuration { get; }
        public EmployeeIdentityServices(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }


        public object Create(TbemployeeIdentity t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    //string id = NumberConstrol.GetNextNumber("IDN");
                    var rawmaxid = db.TbemployeeIdentities.Max(m => m.Id);
                    var maxid = int.Parse(rawmaxid.Replace('I', ' ').Replace('D', ' ').Replace('N', ' '));
                    string id = NumberConstrol.GetNextNumber("IDN");
                    var numid = int.Parse(id.Replace('I', ' ').Replace('D', ' ').Replace('N', ' '));
                    if (numid <= maxid)
                    {
                        id = NumberConstrol.SetNewMaxNumber("IDN", maxid);
                    }


                    var d = new TbemployeeIdentity();
                    d.Id = id;
                    d.IdNumber = t.IdNumber;
                    d.IdType = t.IdType;
                    d.IdExpiryDate = t.IdExpiryDate;
                    d.IdIssuedBy = t.IdIssuedBy;
                    d.Employee = t.Employee;
                    db.TbemployeeIdentities.Add(d);
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

        public IEnumerable<TbemployeeIdentity> CreateOnce(string employeeId, TbemployeeIdentity[] identities)
        {
            var list = new List<TbemployeeIdentity>();
            try
            {
                if (identities != null)
                {
                    if (identities.Length > 0)
                    {
                        foreach (var id in identities)
                        {
                            id.Employee = employeeId;
                            this.Create(id);
                        }
                    }
                }

                return this.GetList(employeeId);
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return list;
            }
        }

        public string Delete(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeIdentities where c.Id == id select c).FirstOrDefault();
                    db.TbemployeeIdentities.Remove(d);
                    db.SaveChanges();
                    db.Dispose();
                }
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return "UNSUCCESS";
            }
        }

        public object Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from employeeIdentities in db.TbemployeeIdentities
                             join identityType in db.TbidentityTypes on employeeIdentities.IdType equals identityType.Id
                             where employeeIdentities.Id == id
                             select new { employeeIdentities, identityType }).FirstOrDefault();
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

        public IEnumerable<TbemployeeIdentity> GetList(string employeeId)
        {
            var list = new List<TbemployeeIdentity>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.TbemployeeIdentities where c.Employee == employeeId select c).ToList();


                    list = db.TbemployeeIdentities.Where(e => e.Employee == employeeId).Select(e => new TbemployeeIdentity {
                        Id = e.Id,
                        IdNumber = e.IdNumber,
                        IdType = e.IdType,
                        IdExpiryDate = e.IdExpiryDate,
                        IdIssuedBy = e.IdIssuedBy,
                        Employee = e.Employee,
                        IdTypeNavigation = new IdentityTypeServices(this.Configuration).Get(e.IdType)

                    }).ToList();
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

        public string Update(string id, TbemployeeIdentity t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeIdentities where c.Id == id select c).FirstOrDefault();
                    if (d == null) throw new Exception("DATA_NOT_FOUND");
                    d.IdNumber = t.IdNumber;
                    d.IdType = t.IdType;
                    d.IdExpiryDate = t.IdExpiryDate;
                    d.IdIssuedBy = t.IdIssuedBy;
                    d.Employee = t.Employee;
                    db.SaveChanges();
                    db.Dispose();
                    return "SUCCESS";
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return "UNSUCCESS";

            }

        }
    }
}
