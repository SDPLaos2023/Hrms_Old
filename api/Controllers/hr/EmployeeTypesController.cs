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
    public class EmployeeTypesController : ControllerBase
    {
        private readonly ILogger<EmployeeTypesController> _logger;
        public IEmployeeTypeServices service { get; }

        public EmployeeTypesController(ILogger<EmployeeTypesController> logger, IEmployeeTypeServices service)
        {
            this._logger = logger;
            this.service = service;
        }

        // GET: api/<EmployeeTypeController>
        [HttpGet]
        public IActionResult Get()
        {
            var wtResp = this.service.GetList();
            if (wtResp == null)
            {
                return NotFound();
            }
            return Ok(wtResp);
        }

        // GET api/<EmployeeTypeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var wtResp = this.service.Get(id);
            if (wtResp == null)
            {
                return NotFound();
            }
            return Ok(wtResp);
        }

        // POST api/<EmployeeTypeController>
        [HttpPost]
        public IActionResult Post([FromBody] TbemployeeType t)
        {
            var wtResp = this.service.Create(t);
            if (wtResp == null)
            {
                return NotFound();
            }
            return Ok(wtResp);
        }

        // PUT api/<EmployeeTypeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TbemployeeType t)
        {
            var wtResp = this.service.Update(id, t);
            if (wtResp == null)
            {
                return NotFound();
            }
            return Ok(wtResp);
        }

        // DELETE api/<EmployeeTypeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var wtResp = this.service.Delete(id);
            if (wtResp == null)
            {
                return NotFound();
            }
            return Ok(wtResp);
        }
    }
}
