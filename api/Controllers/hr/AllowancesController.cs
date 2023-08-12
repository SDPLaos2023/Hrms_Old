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
    public class AllowancesController : ControllerBase
    {
        private readonly IAllowanceServices service;
        private readonly ILog _logger = LogManager.GetLogger(typeof(AllowancesController));

        public AllowancesController(IAllowanceServices service)
        {
            this.service = service;
        }
        // GET: api/<AllowancesController>
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

        // GET api/<AllowancesController>/5
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

        // POST api/<AllowancesController>
        [HttpPost]
        public IActionResult Post([FromBody] Tballowance t)
        {
            var resp = this.service.Create(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // PUT api/<AllowancesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Tballowance t)
        {
            var resp = this.service.Update(id,t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // DELETE api/<AllowancesController>/5
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
