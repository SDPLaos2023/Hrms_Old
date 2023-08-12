using hrm_api.Models;
using hrm_api.Services.Interfaces.attendance;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace hrm_api.Controllers.attendance
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTablesController : ControllerBase
    {

        private readonly ITimetableServices service;
        private readonly ILog _logger = LogManager.GetLogger(typeof(TimeTablesController));

        public TimeTablesController(ITimetableServices service)
        {
            this.service = service;
        }

        // GET: api/<FpDevicesController>
        [HttpGet]
        public IActionResult GetList()
        {
            var resp = this.service.GetList();
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // POST api/<TimeTablesController>
        [HttpPost]
        public IActionResult Post([FromBody] Tbtimetable t)
        {
            var resp = this.service.Create(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // PUT api/<TimeTablesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Tbtimetable t)
        {
            var resp = this.service.Update(id,t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        // DELETE api/<TimeTablesController>/5
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

        [HttpPost("shift/create")]
        public IActionResult CreateShift([FromBody] Tbshiftmanagement t)
        {
            var resp = this.service.CreateShift(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpPost("shift/update")]
        public IActionResult UpdateShift([FromBody] Tbshiftmanagement t)
        {
            var resp = this.service.UpdateShift(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpPost("shift/delete")]
        public IActionResult DeleteShift([FromBody] Tbshiftmanagement t)
        {
            var resp = this.service.DeleteShift(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }


        [HttpPost("shift")]
        public IActionResult GetAllShift([FromBody] Inquiry inq )
        {
            var resp = this.service.GetAllShift(inq);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpPost("shift/detail")]
        public IActionResult GetAllShiftDetailList([FromBody] Inquiry inq)
        {
            var resp = this.service.GetAllShiftDetailList(inq);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }


        [HttpPost("shift/detail/create")]
        public IActionResult CreateShiftDetail([FromBody] List<Tbshiftdetail> list)
        {
            var resp = this.service.CreateShiftDetail(list);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpPost("shift/detail/update")]
        public IActionResult UpdateShiftDetail([FromBody] Tbshiftdetail t)
        {
            var resp = this.service.UpdateShiftDetail(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpPost("shift/detail/delete")]
        public IActionResult DeleteShiftDetail([FromBody] Tbshiftdetail t)
        {
            var resp = this.service.DeleteShiftDetail(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }
    }
}
