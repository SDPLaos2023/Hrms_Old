using hrm_api.Models;
using hrm_api.Models.hr;
using hrm_api.Services.Interfaces.hr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hrm_api.Controllers.hr
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ILogger<CompaniesController> _logger;
        public IConfiguration Configuration { get; }
        private readonly ICompanyService _conmpayService;

        public CompaniesController(ILogger<CompaniesController> logger, ICompanyService conmpayService)
        {
            this._logger = logger;
            this._conmpayService = conmpayService;
        }
        // GET: api/<CompaniesController>
        [HttpGet]
        public IActionResult GetList()
        {
            var companies = this._conmpayService.GetList();
            if (companies == null) {
                return NotFound();
            }
            return Ok(companies);
        }

        // GET api/<CompaniesController>/5
        [HttpGet("{id}")]
        public IActionResult GetCompany(string id)
        {
            var company = this._conmpayService.GetCompany(id);
            if (company == null) {
                return NotFound();
            }
            return Ok(company);
        }

        // POST api/<CompaniesController>
        [HttpPost]
        public IActionResult Create([FromBody] Tbcompany company)
        {
            var result = this._conmpayService.Create(company);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // PUT api/<CompaniesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Tbcompany company)
        {
            var result = this._conmpayService.Update(id, company);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
              
    }
}
