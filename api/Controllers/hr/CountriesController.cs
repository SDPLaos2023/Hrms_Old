using hrm_api.Models;
using hrm_api.Services.Interfaces.hr;
using log4net;
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
    public class CountriesController : ControllerBase
    {
        private readonly ICountryServices service;
        private readonly ILog _logger = LogManager.GetLogger(typeof(CountriesController));

        public CountriesController(ILogger<CountriesController> logger, ICountryServices service)
        {
            this.service = service;
        }

        // GET: api/<CountryController>
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

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var bg = this.service.Get(id) ;
            if (bg == null)
            {
                return NotFound();
            }
            return Ok(bg);
        }

        // POST api/<CountryController>
        [HttpPost]
        public IActionResult Post([FromBody] Tbcountry country)
        {
            var bg = this.service.Create(country);
            if (bg == null)
            {
                return NotFound();
            }
            return Ok(bg);
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Tbcountry country)
        {
             var bg = this.service.Update(id,country);
            if (bg == null)
            {
                return NotFound();
            }
            return Ok(bg);
        }

        // DELETE api/<CountryController>/5
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
