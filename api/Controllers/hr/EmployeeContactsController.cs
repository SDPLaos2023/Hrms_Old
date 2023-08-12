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
    public class EmployeeContactsController : ControllerBase
    {
        private readonly IEmployeeContactServices service;
        //private readonly ILogger<EmployeeContactsController> logger;

        public EmployeeContactsController( IEmployeeContactServices service)
        {
            this.service = service;
            

        }
        
        // GET api/<EmployeeContactsController>/5
        [HttpGet("{emp_id}")]
        public IActionResult Get(string emp_id)
        {
            //Get by employee id
            var resp = this.service.Get(emp_id);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // POST api/<EmployeeContactsController>
        [HttpPost]
        public IActionResult Post([FromBody] TbemployeeContact t)
        {
            var resp = this.service.Create(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // PUT api/<EmployeeContactsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TbemployeeContact t)
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
