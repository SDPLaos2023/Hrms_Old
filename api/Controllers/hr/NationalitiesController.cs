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
    public class NationalitiesController : ControllerBase
    {
        private readonly ILogger<NationalitiesController> _logger;
        public INationalyAndRaceServices _services { get; }

        public NationalitiesController(ILogger<NationalitiesController> logger, INationalyAndRaceServices service)
        {
            this._logger = logger;
            this._services = service;
        }
        // GET: api/<NationalityController>
        [HttpGet]
        public IActionResult Get()
        {
            var nationality = this._services.GetListNationalities();
            if (nationality == null)
            {
                return NotFound();
            }
            return Ok(nationality);
        }

        // GET api/<NationalityController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var nato = this._services.GetNationalitie(id);
            if (nato == null)
            {
                return NotFound();
            }
            return Ok(nato);
        }

        // POST api/<NationalityController>
        [HttpPost]
        public IActionResult Post([FromBody] Tbnationality req)
        {
            using (var db = new hrm_projectContext())
            {
                var nato = this._services.CreateNationality(req);
                if (nato == null)
                {
                    return NotFound();
                }
                return Ok(nato);
            }
        }

        // PUT api/<NationalityController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Tbnationality req)
        {
            using (var db = new hrm_projectContext())
            {
                var nato = this._services.UpdateNationality(id,req);
                if (nato == null)
                {
                    return NotFound();
                }
                return Ok(nato);
            }
        }

        // DELETE api/<NationalityController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            using (var db = new hrm_projectContext())
            {
                var nato = this._services.DeleteNationality(id);
                if (nato == null)
                {
                    return NotFound();
                }
                return Ok(nato);
            }
        }
    }
}
