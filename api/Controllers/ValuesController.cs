using hrm_api.Models.hr;
using hrm_api.Services.Interfaces.hr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IEmployeeServices service { get; }

        public ValuesController()
        {
           
        }

        [HttpPost("tesssssst")]
        public IActionResult Post([FromBody] CreateEmployeeRequest t)
        {
            Console.WriteLine(t);
            var resp = this.service.CreateOnce(t);
            if (resp == null)
            {
                return NotFound();
            }
            return Ok(resp);
        }
    }
}
