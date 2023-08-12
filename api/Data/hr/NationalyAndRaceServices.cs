using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using hrm_api.Services.Interfaces.hr;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using log4net;

namespace hrm_api.Data.hr
{
    public class NationalyAndRaceServices : INationalyAndRaceServices
    {
        public NationalyAndRaceServices(IConfiguration configuration)
        {
            
            this.Configuration = configuration;
        }

        private readonly ILog _logger = LogManager.GetLogger(typeof(NationalyAndRaceServices));

        public IConfiguration Configuration { get; }
        public string CreateNationality(Tbnationality nationality)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string ID = NumberConstrol.GetNextNumber("N");
                    var obj = new Tbnationality()
                    {
                        Id = ID,
                        Name = nationality.Name,
                        NameEn = nationality.NameEn,
                        Code = nationality.Code,
                        Status = nationality.Status
                    };
                    db.Tbnationalities.Add(obj);
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

        public string CreateRace(Tbrace race)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    string ID = NumberConstrol.GetNextNumber("R");
                    var obj = new Tbrace()
                    {
                        Id = ID,
                        Name = race.Name,
                        NameEn = race.NameEn,
                        Code = race.Code,
                        Status = race.Status
                    };

                    db.Tbraces.Add(obj);
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

        public string DeleteNationality(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var obj = (from c in db.Tbnationalities where c.Id == id select c).FirstOrDefault();
                    obj.Status = "DELETED";
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

        public string DeleteRace(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var obj = (from c in db.Tbraces where c.Id == id select c).FirstOrDefault();
                    obj.Status = "DELETED";
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

        public Tbnationality GetNationalitie(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var obj = (from c in db.Tbnationalities where c.Id == id select c).FirstOrDefault();
                    db.Dispose();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return null;

            }
        }

        public IEnumerable<Tbnationality> GetListNationalities()
        {
            var list = new List<Tbnationality>();
            try
            {
  using (var db = new hrm_projectContext())
            {
                list = (from c in db.Tbnationalities where c.Status != "DELETED" select c).ToList();
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

        public Tbrace GetRace(string id)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var obj = (from c in db.Tbraces where c.Id == id select c).FirstOrDefault();
                    db.Dispose();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return null;
            }
        }

        public IEnumerable<Tbrace> GetListRaces()
        {
            var list = new List<Tbrace>();
            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.Tbraces where c.Status != "DELETED" select c).ToList();
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

        public string UpdateNationality(string id, Tbnationality nationality)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                   var obj = (from c in db.Tbnationalities where c.Id ==id select c).FirstOrDefault();
                    obj.Name = nationality.Name;
                    obj.NameEn = nationality.NameEn;
                    obj.Code = nationality.Code;
                    obj.Status = nationality.Status;
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

        public string UpdateRace(string id, Tbrace race)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var obj = (from c in db.Tbraces where c.Id == id select c).FirstOrDefault();
                    obj.Name = race.Name;
                    obj.NameEn = race.NameEn;
                    obj.Code = race.Code;
                    obj.Status = race.Status;
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
