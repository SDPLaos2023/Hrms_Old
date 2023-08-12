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
    public class WorkingTypesController : ControllerBase
    {
        private readonly ILogger<WorkingTypesController> _logger;
        public IWorkingTypeServices service { get; }

        public WorkingTypesController(ILogger<WorkingTypesController> logger, IWorkingTypeServices service)
        {
            this._logger = logger;
            this.service = service;
        }
        // GET: api/<WorkingTypeController>
        [HttpGet]
        public IActionResult Get()
        {
            var wtResp = this.service.GetList();
            if (wtResp == null)
            {
                return NotFound();
            }
            return Ok(wtResp);
        }

        // GET api/<WorkingTypeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var wt = this.service.Get(id);
            if (wt == null)
            {
                return NotFound();
            }
            return Ok(wt);
        }

        // POST api/<WorkingTypeController>
        [HttpPost]
        public IActionResult Post([FromBody] TbworkingType wt)
        {
            var wtResp = this.service.Create(wt);
            if (wtResp == null)
            {
                return NotFound();
            }
            return Ok(wtResp);
        }

        // PUT api/<WorkingTypeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TbworkingType wt)
        {
            var wtResp = this.service.Update(id,wt);
            if (wtResp == null)
            {
                return NotFound();
            }
            return Ok(wtResp);
        }

        // DELETE api/<WorkingTypeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var wtResp = this.service.Delete(id);
            if (wtResp == null)
            {
                return NotFound();
            }
            return Ok(wtResp);
        }
    }
}
