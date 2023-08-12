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
    public class EmployeeCategoriesController : ControllerBase
    {
        private readonly ILogger<EmployeeCategoriesController> _logger;
        public IEmployeeCategoryServices service { get; }

        public EmployeeCategoriesController(ILogger<EmployeeCategoriesController> logger, IEmployeeCategoryServices service)
        {
            this._logger = logger;
            this.service = service;
        }

        // GET: api/<EmployeeCategoriesController>
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

        // GET api/<EmployeeCategoriesController>/5
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

        // POST api/<EmployeeCategoriesController>
        [HttpPost]
        public IActionResult Post([FromBody] TbemployeeCatagory t)
        {
            var wtResp = this.service.Create(t);
            if (wtResp == null)
            {
                return NotFound();
            }
            return Ok(wtResp);
        }

        // PUT api/<EmployeeCategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TbemployeeCatagory t)
        {
            var wtResp = this.service.Update(id,t);
            if (wtResp == null)
            {
                return NotFound();
            }
            return Ok(wtResp);
        }

        // DELETE api/<EmployeeCategoriesController>/5
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
