using hrm_api.Models;
using hrm_api.Models.hr;
using hrm_api.Services.Interfaces.hr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net.Config;
using log4net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hrm_api.Controllers.hr
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeServices service;
        private static readonly ILog log = LogManager.GetLogger(typeof(EmployeesController));
        public EmployeesController(IEmployeeServices service)
        {
            this.service = service;

        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public IActionResult Get()
        {
            var resp = this.service.GetList();
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpGet("none-users")]
        public IActionResult GetNoneUser()
        {
            var resp = this.service.GetListNoneUser();
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // GET api/<EmployeesController>/5
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

        // POST api/<EmployeesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateEmployeeRequest t)
        {
           
            var resp = this.service.CreateOnce(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpPost("get-name/{id}")]
        public IActionResult GetEmployeeName(string id)
        {
            var resp = this.service.GetEmployeeName(id);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] CreateEmployeeRequest t)
        {
            var resp = this.service.UpdateOnce(id, t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // DELETE api/<EmployeesController>/5
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


        [HttpPost("getlist/{department}")]
        public IActionResult GetEmployeeByDepartment(string department)
        {
            var resp = this.service.GetEmployeeDepartment(department);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }
    }
}
