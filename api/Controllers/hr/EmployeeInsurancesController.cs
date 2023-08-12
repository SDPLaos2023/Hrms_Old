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
    public class EmployeeInsurancesController : ControllerBase
    {
        // GET: api/<EmployeeInsurancesController>
        private readonly IEmployeeInsuranceServices service;
        //private readonly ILogger<EmployeeInsurancesController> logger;

        public EmployeeInsurancesController(IEmployeeInsuranceServices service)
        {
            this.service = service;
        }

        // GET api/<EmployeeContractsController>/5
        [HttpGet("{emp_id}")]
        public IActionResult Get(string emp_id)
        {
            var resp = this.service.GetInsurance(emp_id);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // POST api/<EmployeeInsurancesController>
        [HttpPost]
        public IActionResult Post([FromBody] TbemployeeInsurance t)
        {
            var resp = this.service.Create(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // PUT api/<EmployeeInsurancesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TbemployeeInsurance t)
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
