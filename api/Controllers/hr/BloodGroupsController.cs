using hrm_api.Models;
using hrm_api.Services.Interfaces.hr;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace hrm_api.Controllers.hr
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BloodGroupsController : ControllerBase
    {
        private readonly IBloodGroupServices service;
        private readonly ILog _logger = LogManager.GetLogger(typeof(BloodGroupsController));

        public BloodGroupsController(ILogger<BloodGroupsController> logger, IBloodGroupServices service)
        {
            this.service = service;
            

        }
        // GET: api/<BloodGroupController>
        [HttpGet]
        public IActionResult Get()
        {
            var bg = this.service.GetList();
            if (bg == null)
            {
                return NotFound();
            }
            return Ok(bg);
        }

        // GET api/<BloodGroupController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var bg = this.service.Get(id);
            if (bg == null)
            {
                return NotFound();
            }
            return Ok(bg);
        }

        // POST api/<BloodGroupController>
        [HttpPost]
        public IActionResult Post([FromBody] Tbbloodgroup req)
        {
            var bg = this.service.Create(req);
            if (bg == null)
            {
                return NotFound();
            }
            return Ok(bg);
        }

        // PUT api/<BloodGroupController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Tbbloodgroup req)
        {
            var bg = this.service.Update(id,req);
            if (bg == null)
            {
                return NotFound();
            }
            return Ok(bg);
        }

        // DELETE api/<BloodGroupController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var bg = this.service.Delete(id);
            if (bg == null)
            {
                return NotFound();
            }
            return Ok(bg);
        }
    }
}
