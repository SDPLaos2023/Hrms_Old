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
    public class ResignationReasonsController : ControllerBase
    {
        private readonly ILogger<ResignationReasonsController> _logger;
        public IResignationReasonServices service { get; }

        public ResignationReasonsController(ILogger<ResignationReasonsController> logger, IResignationReasonServices service)
        {
            this._logger = logger;
            this.service = service;
        }
        // GET: api/<ResignationReasonsController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.service.GetList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET api/<ResignationReasonsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var result = this.service.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/<ResignationReasonsController>
        [HttpPost]
        public IActionResult Post([FromBody] Tbresignationreason t)
        {
            var result = this.service.Create(t);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // PUT api/<ResignationReasonsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Tbresignationreason t)
        {
            var result = this.service.Update(id, t);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // DELETE api/<ResignationReasonsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var result = this.service.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
