using hrm_api.Models;
using hrm_api.Services.Interfaces.auth;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hrm_api.Controllers.auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices service;
        private readonly ILog log = LogManager.GetLogger(typeof(UsersController));

        public UsersController(IUserServices _service)
        {
            this.service = _service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var resp = this.service.GetList();
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AuthUser t)
        {
            var resp = this.service.Create(t);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] AuthUser t)
        {
            var resp = this.service.Update(id,t);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [HttpPost("{id}")]
        public IActionResult Get(string id )
        {
            var resp = this.service.Get(id );
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var resp = this.service.Delete(id);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [HttpPost("chw/{id}")]
        public IActionResult ChangePassword(string id, [FromBody] AuthUser t)
        {
            var resp = this.service.ChangePassword(id, t);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }
    }
}
