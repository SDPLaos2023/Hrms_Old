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
    public class EmployeeSalarySettingsController : ControllerBase
    {
        private readonly IEmployeeSalaryServices service;
        //private readonly ILogger<EmployeeSalarySettingsController> logger;

        public EmployeeSalarySettingsController(IEmployeeSalaryServices service)
        {
            this.service = service;
        }

        [HttpGet("{emp_id}")]
        public IActionResult Get(string emp_id)
        {
            var resp = this.service.GetSalarySetting(emp_id);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // POST api/<EmployeeSalarySettingsController>
        [HttpPost]
        public IActionResult Post([FromBody] TbemployeeSalarySetting t)
        {
            var resp = this.service.Create(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // PUT api/<EmployeeSalarySettingsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TbemployeeSalarySetting t)
        {
            var resp = this.service.Update(id,t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }
    }
}
