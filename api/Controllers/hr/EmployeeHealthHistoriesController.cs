using hrm_api.Models;
using hrm_api.Services.Interfaces.hr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace hrm_api.Controllers.hr
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeHealthHistoriesController : ControllerBase
    {
        private readonly IEmployeeHealthHistoryServices service;
        //private readonly ILogger<EmployeeHealthHistoriesController> logger;

        public EmployeeHealthHistoriesController(IEmployeeHealthHistoryServices service)
        {
            this.service = service;
            

        }

        [HttpGet("{emp_id}")]
        public IActionResult GetList(string emp_id)
        {
            var resp = this.service.GetList(emp_id);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }
      
        [HttpPost]
        public IActionResult Post([FromBody] TbemployeeHealthHistory t)
        {
            var resp = this.service.Create(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TbemployeeHealthHistory t)
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
