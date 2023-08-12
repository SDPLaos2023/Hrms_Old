using hrm_api.Models;
using hrm_api.Services.Interfaces.hr;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hrm_api.Controllers.hr
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAllowancesController : ControllerBase
    {
        private readonly IEmployeeAllowanceServices service;
        public EmployeeAllowancesController(IEmployeeAllowanceServices service)
        {
            this.service = service;
        }

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

        [HttpPost]
        public IActionResult Post([FromBody] TbemployeeAllowance t)
        {
            var resp = this.service.Create(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TbemployeeAllowance t)
        {
            var resp = this.service.Update(id,t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

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
