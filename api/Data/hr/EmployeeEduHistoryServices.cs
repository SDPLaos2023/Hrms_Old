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
    public class EmployeeEduHistoryServices : IEmployeeEduHistoryServices
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(EmployeeEduHistoryServices));
        public EmployeeEduHistoryServices(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public TbemployeeEducationHistory Create(TbemployeeEducationHistory t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    //string id = NumberConstrol.GetNextNumber("EE");
                    var rawmaxid = db.TbemployeeEducationHistories.Max(m => m.Id);
                    var maxid = int.Parse(rawmaxid.Replace('E', ' ') );
                    string id = NumberConstrol.GetNextNumber("EE");
                    var numid = int.Parse(id.Replace('E', ' ') );
                    if (numid <= maxid)
                    {
                        id = NumberConstrol.SetNewMaxNumber("EE", maxid);
                    }

                    var d = new TbemployeeEducationHistory();
                    d.Id = id;
                    d.Employee = t.Employee;
                    d.Institution = t.Institution;
                    d.Degree = t.Degree;
                    d.Year = t.Year;
                    d.Major = t.Major;
                    d.Gpa = t.Gpa;
                    d.Sequence = t.Sequence;
                    db.TbemployeeEducationHistories.Add(d);
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

        public IEnumerable<TbemployeeEducationHistory> CreateOnce(string employeeId, TbemployeeEducationHistory[] edus)
        {
            var list = new List<TbemployeeEducationHistory>();
            try
            {
                if (edus != null)
                {
                    if (edus.Length > 0)
                    {
                        foreach (var item in edus)
                        {
                            item.Employee = employeeId;
                            this.Create(item);
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
                    var d = (from c in db.TbemployeeEducationHistories where c.Id == id select c).FirstOrDefault();
                    db.TbemployeeEducationHistories.Remove(d);
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

        public TbemployeeEducationHistory Get(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeEducationHistories where c.Id == id select c).FirstOrDefault();
                    return d;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return null;
            }
        }

        public IEnumerable<TbemployeeEducationHistory> GetList(string employeeId)
        {
            var list = new List<TbemployeeEducationHistory>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    //list = (from c in db.TbemployeeEducationHistories
                    //        where c.Employee == employeeId
                    //        select c).ToList();

                    var degree = new EducationDegreeTypeServices(this.Configuration);
                    var institution = new InstitutionServices(this.Configuration);
                    var listx = db.TbemployeeEducationHistories.Where(e => e.Employee == employeeId).Select(e => new TbemployeeEducationHistory
                    {
                        Id = e.Id,
                        Employee = e.Employee,
                        Institution = e.Institution,
                        Degree = e.Degree,
                        Year = e.Year,
                        Major = e.Major,
                        Gpa = e.Gpa,
                        Sequence = e.Sequence,
                        DegreeNavigation = degree.Get(e.Degree),
                        InstitutionNavigation = institution.Get(e.Institution)
                    }).ToList();
                    db.Dispose();
                    return listx;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return list;

            }
        }

        public string Update(string id, TbemployeeEducationHistory t)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.TbemployeeEducationHistories where c.Id == id select c).FirstOrDefault();
                    if (d == null) throw new Exception("DATA_NOT_FOUND");
                    d.Employee = t.Employee;
                    d.Institution = t.Institution;
                    d.Degree = t.Degree;
                    d.Year = t.Year;
                    d.Major = t.Major;
                    d.Gpa = t.Gpa;
                    d.Sequence = t.Sequence;
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
