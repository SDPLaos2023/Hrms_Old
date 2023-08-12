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
    public class DeviceUsersController : ControllerBase
    {
        private readonly IDeviceUsersServices service;
        private readonly ILog _logger = LogManager.GetLogger(typeof(DeviceUsersController));

        public DeviceUsersController(IDeviceUsersServices service)
        {
            this.service = service;
        }
        [HttpGet("{id}/all")]
        public IActionResult GetList(string id)
        {
            var resp = this.service.GetList(id);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpGet("{id}/none-users")]
        public IActionResult GetListNoneUser(string id)
        {
            var resp = this.service.GetListNoneUser(id);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

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

        [HttpPost]
        public IActionResult Post([FromBody] Tbfpuser t)
        {
            var resp = this.service.Create(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Tbfpuser t)
        {
            var resp = this.service.Update(id,t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

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

        [HttpPost("transfer/{newFpId}")]
        public IActionResult TransferUser(string newFpId, [FromBody] Tbfpuser t)
        {
            var resp = this.service.TransferUser(newFpId,t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }

    }
}
