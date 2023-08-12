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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hrm_api.Controllers.hr
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IPositionServices service;
        private readonly ILog _logger = LogManager.GetLogger(typeof(PositionsController));


        public PositionsController(IPositionServices service)
        {
            this.service = service;
            

        }
        // GET: api/<PositionController>
        [HttpGet]
        public IActionResult Get()
        {
            var postion = this.service.GetList();
            if (postion == null)
            {
                return NotFound();
            }
            return Ok(postion);
        }

        // GET api/<PositionController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var postion = this.service.GetPosition(id);
            if (postion == null)
            {
                return NotFound();
            }
            return Ok(postion);
        }

        // POST api/<PositionController>
        [HttpPost]
        public IActionResult Post([FromBody] Tbpostion posi)
        {
            var postion = this.service.Create(posi);
            if (postion == null)
            {
                return NotFound();
            }
            return Ok(postion);
        }

        // PUT api/<PositionController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Tbpostion posi)
        {
            var postion = this.service.Update(id,posi);
            if (postion == null)
            {
                return NotFound();
            }
            return Ok(postion);
        }

        // DELETE api/<PositionController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var postion = this.service.Delete(id);
            if (postion == null)
            {
                return NotFound();
            }
            return Ok(postion);
        }
    }
}
