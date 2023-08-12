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
    public class DivisionsController : ControllerBase
    {
        private readonly IDivisionServices service;
        private readonly ILog _logger = LogManager.GetLogger(typeof(DivisionsController));

        public DivisionsController(ILogger<DivisionsController> logger, IDivisionServices service)
        {
            this.service = service;
            
        }
        // GET: api/<DivisionController>
        [HttpGet]
        public IActionResult Get()
        {
            var division = this.service.GetList();
            if (division == null)
            {
                return NotFound();
            }
            return Ok(division);
        }

        // GET api/<DivisionController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var division = this.service.GetDivision(id);
            if (division == null)
            {
                return NotFound();
            }
            return Ok(division);
        }

        // POST api/<DivisionController>
        [HttpPost]
        public IActionResult Post([FromBody] Tbdivision tbDivision)
        {
            var division = this.service.Create(tbDivision);
            if (division == null)
            {
                return NotFound();
            }
            return Ok(division);

        }

        // PUT api/<DivisionController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Tbdivision tbDivision)
        {
            var division = this.service.Update(id,tbDivision);
            if (division == null)
            {
                return NotFound();
            }
            return Ok(division);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var division = this.service.Delete(id);
            if (division == null)
            {
                return NotFound();
            }
            return Ok(division);

        }
    }
}
