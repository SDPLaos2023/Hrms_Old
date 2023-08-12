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
    [ApiController]
    public class RuleItemsController : ControllerBase
    {
        private readonly IRuleItemServices service;
        private readonly ILog log = LogManager.GetLogger(typeof(RuleItemsController));

        public RuleItemsController(IRuleItemServices _service)
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

        [Route("api/[controller]/rule/{rule_id}")]
        [HttpPost]
        public IActionResult Getlist(string rule_id)
        {
            var resp = this.service.GetList(rule_id);
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

        [Route("api/[controller]/{rule_id}/{page_id}")]
        [HttpPost]
        public IActionResult Post(string rule_id,int page_id)
        {
            var resp = this.service.AddRuleItem(rule_id,page_id);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }


        [Route("api/[controller]/{rule_id}/select-all")]
        [HttpPost]
        public IActionResult AddAllRuleItem(string rule_id)
        {
            var resp = this.service.AddAllRuleItem(rule_id);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [Route("api/[controller]/{id}")]
        [HttpPut]
        public IActionResult Put(string id, [FromBody] TbruleItem t)
        {
            var resp = this.service.Update(id,t);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }

        [Route("api/[controller]/{id}")]
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var resp = this.service.Delete(id);
            if (resp == null)
            {
                return NoContent();
            }
            return Ok(resp);
        }
    }
}
