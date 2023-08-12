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
    public class EmployeeEducationsController : ControllerBase
    {
        private readonly IEmployeeEduHistoryServices service;
        //private readonly ILogger<EmployeeEducationsController> logger;

        public EmployeeEducationsController(IEmployeeEduHistoryServices service)
        {
            this.service = service;
            

        }
        // GET: api/<EmployeeEducationsController>/api/EmployeeIdentities/employee/{cmployeeId}
        [HttpGet("employee/{employeeId}")]
        public IActionResult GetList(string employeeId)
        {
            var resp = this.service.GetList(employeeId);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // GET api/<EmployeeEducationsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var resp = this.service.Get(id);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // POST api/<EmployeeEducationsController>
        [HttpPost]
        public IActionResult Post([FromBody] TbemployeeEducationHistory t)
        {
            var resp = this.service.Create(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // PUT api/<EmployeeEducationsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TbemployeeEducationHistory t)
        {
            var resp = this.service.Update(id,t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // DELETE api/<EmployeeEducationsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var resp = this.service.Delete(id);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }
    }
}
