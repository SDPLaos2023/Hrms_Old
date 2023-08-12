using hrm_api.Models;
using hrm_api.Services.Interfaces.hr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Controllers.hr
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeIdentitiesController : ControllerBase
    {
        private readonly IEmployeeIdentityServices service;

        public EmployeeIdentitiesController(IEmployeeIdentityServices service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody] TbemployeeIdentity t)
        {
            var resp = this.service.Create(t);
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

        [HttpGet("employee/{cmployeeId}")]
        public IActionResult GetList(string cmployeeId)
        {
            var resp = this.service.GetList(cmployeeId);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TbemployeeIdentity t)
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
