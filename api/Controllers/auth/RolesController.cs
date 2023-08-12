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
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly IRoleServices service;
        private readonly ILog log = LogManager.GetLogger(typeof(RolesController));

        public RolesController(IRoleServices _service)
        {
            this.service = _service;
        }

        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Get()
        {
            var resp = this.service.GetList();
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [Route("api/[controller]/{id}")]
        [HttpPost]
        public IActionResult Get(string id)
        {
            var resp = this.service.Get(id);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }
    }
}
