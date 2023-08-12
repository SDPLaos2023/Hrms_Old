using hrm_api.Models;
using hrm_api.Services.Interfaces.hr;
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
    public class RacesController : ControllerBase
    {
        private readonly ILogger<RacesController> _logger;
        public INationalyAndRaceServices _services { get; }
        public RacesController(ILogger<RacesController> logger, INationalyAndRaceServices service)
        {
            this._logger = logger;
            this._services = service;
        }
        // GET: api/<RaceController>
        [HttpGet]
        public IActionResult Get()
        {
            var race = this._services.GetListRaces();
            if (race == null)
            {
                return NotFound();
            }
            return Ok(race);
        }

        // GET api/<RaceController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var nato = this._services.GetRace(id);
            if (nato == null)
            {
                return NotFound();
            }
            return Ok(nato);
        }

        // POST api/<RaceController>
        [HttpPost]
        public IActionResult Post([FromBody] Tbrace req)
        {
            var nato = this._services.CreateRace(req);
            if (nato == null)
            {
                return NotFound();
            }
            return Ok(nato);
        }

        // PUT api/<RaceController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Tbrace req)
        {
            var nato = this._services.UpdateRace(id,req);
            if (nato == null)
            {
                return NotFound();
            }
            return Ok(nato);
        }

        // DELETE api/<RaceController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var nato = this._services.DeleteRace(id);
            if (nato == null)
            {
                return NotFound();
            }
            return Ok(nato);
        }
    }
}
