using hrm_api.Models;
using hrm_api.Services.Interfaces.hr;
using log4net;
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
    public class EmployeeTransactionsController : ControllerBase
    {
        private readonly IEmployeeTransactionServices service;
        private readonly ILog _logger = LogManager.GetLogger(typeof(EmployeeTransactionsController));

        public EmployeeTransactionsController(IEmployeeTransactionServices service)
        {
            this.service = service;
        }

        // GET: api/<EmployeeTransactionsController>
        [HttpGet("employee/{employeeId}")]
        public IActionResult Get(string employeeId)
        {
            var resp = this.service.GetList(employeeId);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // GET api/<EmployeeTransactionsController>/5
        [HttpGet("{id}")]
        public IActionResult GetOne(string id)
        {
            var resp = this.service.Get(id);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // POST api/<EmployeeTransactionsController>
        [HttpPost]
        public IActionResult Post([FromBody] TbemployeeTransaction t)
        {
            var resp = this.service.Create(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // PUT api/<EmployeeTransactionsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TbemployeeTransaction t)
        {
            var resp = this.service.Update(id,t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // DELETE api/<EmployeeTransactionsController>/5
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
