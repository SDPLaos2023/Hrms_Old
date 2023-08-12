using hrm_api.Models;
using hrm_api.Services.Interfaces.hr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hrm_api.Controllers.hr
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeLeaveSettingsController : ControllerBase
    {
        private readonly IEmployeeLeaveSettingServices service;
        //private readonly ILogger<EmployeeLeaveSettingsController> logger;

        public EmployeeLeaveSettingsController(IEmployeeLeaveSettingServices service)
        {
            this.service = service;
            

        }

        // GET api/<EmployeeContractsController>/5
        [HttpGet("{emp_id}")]
        public IActionResult Get(string emp_id)
        {
            var resp = this.service.GetLeaveSetting(emp_id);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // POST api/<EmployeeLeaveSettingsController>
        [HttpPost]
        public IActionResult Post([FromBody] TbemployeeLeaveSetting t)
        {
            var resp = this.service.Create(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // PUT api/<EmployeeLeaveSettingsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TbemployeeLeaveSetting t)
        {
            var resp = this.service.Update(id,t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }


        [HttpPost("leave-request")]
        public IActionResult GetLeaveRequest([FromBody] Inquiry t)
        {
            var resp = this.service.GetLeaveRequest(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpPost("leave-request/create")]
        public IActionResult CreateLeaveRequest([FromBody] TbleaveRequest t)
        {
            var resp = this.service.CreateLeaveRequest(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpPost("leave-request/update")]
        public IActionResult UpdateLeaveRequest([FromBody] TbleaveRequest t)
        {
            var resp = this.service.UpdateLeaveRequest(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpPost("leave-request/delete")]
        public IActionResult DeleteLeaveRequest([FromBody] TbleaveRequest t)
        {
            var resp = this.service.DeleteLeaveRequest(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }
        
        [HttpPost("leave-request/employee")]
        public IActionResult GetEmployeeLeaveRequest([FromBody] Inquiry t)
        {
            var resp = this.service.GetEmployeeLeaveRequest(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }
       
        [HttpPost("leave-request/employee/histories")]
        public IActionResult GetLeaveEmployeeHistory([FromBody] Inquiry t)
        {
            var resp = this.service.GetLeaveEmployeeHistory(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpPost("leave-request/managers/active")]
        public IActionResult GetEmployeeLeaveRequestNeedApproval([FromBody] Inquiry t)
        {
            var resp = this.service.GetEmployeeLeaveRequestNeedApproval(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpPost("leave-request/managers/approved")]
        public IActionResult GetEmployeeLeaveRequestApproved([FromBody] Inquiry t)
        {
            var resp = this.service.GetEmployeeLeaveRequestApproved(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpPost("leave-request/managers/rejected")]
        public IActionResult GetEmployeeLeaveRequestRejected([FromBody] Inquiry t)
        {
            var resp = this.service.GetEmployeeLeaveRequestRejected(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }


        [HttpPost("leave-request/hr/active")]
        public IActionResult GetEmployeeLeaveRequestHrNeedApproval([FromBody] Inquiry t)
        {
            var resp = this.service.GetEmployeeLeaveRequestHrNeedApproval(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpPost("leave-request/hr/approved")]
        public IActionResult GetEmployeeLeaveRequestHrApproved([FromBody] Inquiry t)
        {
            var resp = this.service.GetEmployeeLeaveRequestHrApproved(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpPost("leave-request/hr/rejected")]
        public IActionResult GetEmployeeLeaveRequestHrRejected([FromBody] Inquiry t)
        {
            var resp = this.service.GetEmployeeLeaveRequestHrRejected(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpPost("leave/employee/summary")]
        public IActionResult GetEmployeeLeaveSummary([FromBody] Inquiry t)
        {
            var resp = this.service.GetEmployeeLeaveSummary(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpPost("leave/employee/leave-remain")]
        public IActionResult GetEmployeeLeaveRemain([FromBody] Inquiry t)
        {
            var resp = this.service.GetEmployeeLeaveRemain(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpPost("leave/employee/leave-count")]
        public IActionResult GetEmployeeLeaveCount([FromBody] Inquiry t)
        {
            var resp = this.service.GetEmployeeLeaveCount(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }
    }
}
