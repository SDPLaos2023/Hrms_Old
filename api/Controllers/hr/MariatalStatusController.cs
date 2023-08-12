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
    public class MariatalStatusController : ControllerBase
    {
        private readonly ILogger<MariatalStatusController> _logger;
        public IMaritalStatusServices service { get; }

        public MariatalStatusController(ILogger<MariatalStatusController> logger, IMaritalStatusServices service)
        {
            this._logger = logger;
            this.service = service;
        }
        // GET: api/<MariatalStatusController>
        [HttpGet]
        public IActionResult Get()
        {
            var mrts = this.service.GetList();
            if (mrts == null)
            {
                return NotFound();
            }
            return Ok(mrts);
        }

        // GET api/<MariatalStatusController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var mrts = this.service.Get(id);
            if (mrts == null)
            {
                return NotFound();
            }
            return Ok(mrts);
        }

        // POST api/<MariatalStatusController>
        [HttpPost]
        public IActionResult Post([FromBody] Tbmarriage mrtsReq)
        {
            var mrts = this.service.Create(mrtsReq);
            if (mrts == null)
            {
                return NotFound();
            }
            return Ok(mrts);
        }

        // PUT api/<MariatalStatusController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Tbmarriage mrtsReq)
        {
            var mrts = this.service.Update(id,mrtsReq);
            if (mrts == null)
            {
                return NotFound();
            }
            return Ok(mrts);
        }

        // DELETE api/<MariatalStatusController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var mrts = this.service.Delete(id);
            if (mrts == null)
            {
                return NotFound();
            }
            return Ok(mrts);
        }
    }
}
