using hrm_api.Models.attendance;
using hrm_api.Services.Interfaces.attendance;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hrm_api.Models;
using Newtonsoft.Json;
using static hrm_api.Models.dbContext;

namespace hrm_api.Controllers.attendance
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetsController : ControllerBase
    {

        private readonly ITimesheetService service;
        private readonly ILog log = LogManager.GetLogger(typeof(TimesheetsController));

        public TimesheetsController(ITimesheetService service)
        {
            this.service = service;
        }

        // GET: api/<FpDevicesController>
        [HttpPost("time-att-logs")]
        public IActionResult GetDepartmentAttLogs([FromBody] TimesheetInq req)
        {
            var resp = this.service.GetAttendanceByDepartment(req);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [HttpPost("time-att-log")]
        public IActionResult GetPersonAttLogs([FromBody] TimesheetInq req)
        {
            log.Info(JsonConvert.SerializeObject(req));
            var resp = this.service.GetPersonTimesheet(req);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [HttpPost("upload")]
        public IActionResult Upload([FromBody] List<Tbattlog> req)
        {
            //Console.WriteLine(JsonConvert.SerializeObject(req));
            //_logger.Info(JsonConvert.SerializeObject(req));
            var resp = this.service.UploadAttendanceLog(req);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [HttpPost("re-attendance")]
        public IActionResult ReCalculate (List<FpRecalculateRequest> l)
        {
            var resp = this.service.RecalculateData(l);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [HttpPost("testtt")]
        public IActionResult testtt()
        {
            var resp = this.service.Tests();
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [HttpPost("getusertimesheetbydate")]
        public IActionResult GetUserTimesheetByDate([FromBody] TimesheetInq req)
        {
            log.Info(JsonConvert.SerializeObject(req));
            var resp = this.service.GetTimesheetByDate(req);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [HttpPost("getusertimesheetbydepartmentdate")]
        public IActionResult GetUserTimesheetByDateUpdate([FromBody] TimesheetInq req)
        {
            log.Info(JsonConvert.SerializeObject(req));
            var resp = this.service.GetUserTimesheetByDate(req);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [HttpPost("updatetimesheetadjustment")]
        public IActionResult UpdateTimesheet([FromBody] List<Timesheet> req)
        {
            log.Info(JsonConvert.SerializeObject(req));
            var resp = this.service.UpdateTimesheet(req);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [HttpPost("getalltimesheetmonthly")]
        public IActionResult GetAllTimesheetMonthly([FromBody] TimesheetInq req)
        {
            log.Info(JsonConvert.SerializeObject(req));
            var resp = this.service.GetAllTimesheetMonthly(req);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [HttpPost("addtime")]
        public IActionResult AddTimeManual([FromBody]List<AddTimeRequest> req)
        {
            log.Info(JsonConvert.SerializeObject(req));
            var resp = this.service.AddTime(req);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [HttpPost("addtime-inq")]
        public IActionResult AddTimeInq([FromBody] AddTimeRequest req)
        {
            log.Info(JsonConvert.SerializeObject(req));
            var resp = this.service.GetTimesheetByFpUser(req);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }


        [HttpPost("addlog")]
        public IActionResult AddLog([FromBody] List<AddTimeRequest> req)
        {
            log.Info(JsonConvert.SerializeObject(req));
            var resp = this.service.AddLog(req);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [HttpPost("calcalate")]
        public IActionResult CalculateAttendance([FromBody] CalculateAttendanceRequest req)
        {
            log.Info(JsonConvert.SerializeObject(req));
            var resp = this.service.CalculateAttendance(req);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [HttpPost("workingperiod/{company}")]
        public IActionResult GetWorkingPeriodList(string company)
        {
            var resp = this.service.GetWorkingPeriodList(company);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [HttpPost("workingperiod/create")]
        public IActionResult NewWorkingPeriod(Tbworkingperiod t)
        {
            var resp = this.service.NewWorkingPeriod(t);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [HttpPost("workingperiod/update")]
        public IActionResult UpdateWorkingPeriod(Tbworkingperiod t)
        {
            var resp = this.service.UpdateWorkingPeriod(t);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [HttpPost("workingperiod/active/{wkpid}")]
        public IActionResult ActiveWorkingPeriod(string wkpid)
        {
            var resp = this.service.ActiveWorkingPeriod(wkpid);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }


        [HttpPost("workingperiod/fpuser/{fpuserid}")]
        public IActionResult GetUserWorkingPeriod(string fpuserid)
        {
            var resp = this.service.GetUserWorkingPeriod(fpuserid);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [HttpPost("timeassigment/{employee}")]
        public IActionResult GetEmployeeTimeAssignment(string employee)
        {
            var resp = this.service.GetEmployeeTimeAssignment(employee);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

    }
}
