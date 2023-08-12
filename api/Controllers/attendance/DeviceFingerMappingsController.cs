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
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceFingerMappingsController : ControllerBase
    {
        private readonly IDeviceUserFingerMappingServices service;
        private readonly ILog _logger = LogManager.GetLogger(typeof(DeviceFingerMappingsController));

        public DeviceFingerMappingsController(IDeviceUserFingerMappingServices service)
        {
            this.service = service;
        }

        // GET: api/<FpDevicesController>
        [HttpGet("fingerprint/{id}")]
        public IActionResult GetList(string id)
        {
            var resp = this.service.GetList(id);
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
        public IActionResult Post([FromBody] Tbfingerprintmapping t)
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
        public IActionResult Put(string id, [FromBody] Tbfingerprintmapping t)
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
