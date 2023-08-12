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
    public class EmployeeClassificationsController : ControllerBase
    {
        private readonly IEmployeeClassificationServices service;
        //private readonly ILogger<EmployeeClassificationsController> logger;

        public EmployeeClassificationsController(IEmployeeClassificationServices service)
        {
            this.service = service;
            

        }
       

        // GET api/<EmployeeClassificationsController>/5
        [HttpGet("{emp_id}")]
        public IActionResult Get(string emp_id)
        {
            var resp = this.service.GetClassification(emp_id);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // POST api/<EmployeeClassificationsController>
        [HttpPost]
        public IActionResult Post([FromBody] TbemployeeClassification t)
        {
            var resp = this.service.Create(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // PUT api/<EmployeeClassificationsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TbemployeeClassification t)
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
