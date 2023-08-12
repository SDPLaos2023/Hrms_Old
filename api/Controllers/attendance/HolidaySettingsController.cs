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
    public class HolidaySettingsController : ControllerBase
    {

        private readonly IHolidaySettingServices service;
        private readonly ILog _logger = LogManager.GetLogger(typeof(HolidaySettingsController));

        public HolidaySettingsController(IHolidaySettingServices service)
        {
            this.service = service;
        }

        // GET: api/<HolidaySettingsController>
        [HttpGet]
        public IActionResult Get()
        {
            var resp = this.service.GetListDraff();
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // GET api/<HolidaySettingsController>/5
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

        [HttpGet("active/{year}")]
        public IActionResult GetList(string year)
        {
            var resp = this.service.GetList(year);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // POST api/<HolidaySettingsController>
        [HttpPost]
        public IActionResult Post([FromBody] TbholidaySetting t)
        {
            var resp = this.service.Create(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // PUT api/<HolidaySettingsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TbholidaySetting t)
        {
            var resp = this.service.Update(id,t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // DELETE api/<HolidaySettingsController>/5
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

        [HttpPost("bydate")]
        public IActionResult GetListHolidayByDate([FromBody] Inquiry t)
        {
            var resp = this.service.GetListHolidayByDate(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }
    }
}
