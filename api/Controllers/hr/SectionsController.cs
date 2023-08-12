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
    public class SectionsController : ControllerBase
    {
        private readonly ISectionServices service;
        private readonly ILog _logger = LogManager.GetLogger(typeof(SectionsController));

        public SectionsController(ILogger<SectionsController> logger, ISectionServices service)
        {
            this.service = service;
            

        }
        // GET: api/<SectionController>
        [HttpGet]
        public IActionResult Get()
        {
            var section = this.service.GetList();
            if (section == null)
            {
                return NotFound();
            }
            return Ok(section);
        }

        // GET api/<SectionController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var section = this.service.GetSection(id);
            if (section == null)
            {
                return NotFound();
            }
            return Ok(section);
        }

        // POST api/<SectionController>
        [HttpPost]
        public IActionResult Post([FromBody] Tbsection sect)
        {
            var section = this.service.Create(sect);
            if (section == null)
            {
                return NotFound();
            }
            return Ok(section);
        }

        // PUT api/<SectionController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Tbsection sect)
        {
            var section = this.service.Update(id,sect);
            if (section == null)
            {
                return NotFound();
            }
            return Ok(section);
        }

        // DELETE api/<SectionController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var section = this.service.Delete(id);
            if (section == null)
            {
                return NotFound();
            }
            return Ok(section);
        }
    }
}
