using hrm_api.Models;
using hrm_api.Services.Interfaces.attendance;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hrm_api.Controllers.attendance
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FpDevicesController : ControllerBase
    {

        private readonly IDeviceManagerServices service;
        private readonly ILog _logger = LogManager.GetLogger(typeof(FpDevicesController));

        public FpDevicesController(IDeviceManagerServices service)
        { 
            this.service = service;
        }

        // GET: api/<FpDevicesController>
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

        // GET api/<FpDevicesController>/5
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

        // POST api/<FpDevicesController>
        [HttpPost]
        public IActionResult Post([FromBody] Tbfingerprint t)
        {
            var resp = this.service.Create(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // PUT api/<FpDevicesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Tbfingerprint t)
        {
            var resp = this.service.Update(id, t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // DELETE api/<FpDevicesController>/5
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
