using hrm_api.Services.Interfaces.auth;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Controllers.auth
{
    [ApiController]
    public class PageMastersController : ControllerBase
    {
        private readonly IPageMasterServices service;
        private readonly ILog log = LogManager.GetLogger(typeof(PageMastersController));

        public PageMastersController(IPageMasterServices _service)
        {
            this.service = _service;
        }

        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult GetList() {
            var resp = this.service.GetList();
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [Route("api/[controller]/{pageGroup}")]
        [HttpPost]
        public IActionResult GetList(string pageGroup)
        {
            var resp = this.service.GetList(pageGroup);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

    }
}
