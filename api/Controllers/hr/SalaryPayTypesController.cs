using hrm_api.Models;
using hrm_api.Services.Interfaces.hr;
using log4net;
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
    public class SalaryPayTypesController : ControllerBase
    {
        private readonly ISalaryPayTypeServices service;
        private readonly ILog _logger = LogManager.GetLogger(typeof(SalaryPayTypesController));
        //TbsalaryPayType
        public SalaryPayTypesController(ILogger<SalaryPayTypesController> logger, ISalaryPayTypeServices service)
        {
            this.service = service;
            

        }
        // GET: api/<SalaryPayTypesController>
        [HttpGet]
        public IActionResult Get()
        {
            var resp = this.service.GetList();
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // GET api/<SalaryPayTypesController>/5
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

        // POST api/<SalaryPayTypesController>
        [HttpPost]
        public IActionResult Post([FromBody] TbsalaryPayType t)
        {
            var resp = this.service.Create(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // PUT api/<SalaryPayTypesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TbsalaryPayType t)
        {
            var resp = this.service.Update(id, t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // DELETE api/<SalaryPayTypesController>/5
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
