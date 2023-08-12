using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using hrm_api.Services.Interfaces.hr;
using hrm_api.Models;
using Microsoft.AspNetCore.Authorization;
using log4net;

namespace hrm_api.Controllers.hr
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentServices service;
        private readonly ILog _logger = LogManager.GetLogger(typeof(DepartmentsController));
        public DepartmentsController(IDepartmentServices service, ILogger<DepartmentsController> logger)
        {
            
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            try
            {
                var resp = this.service.GetList();
                return Ok(resp);
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartment(string id)
        {
            try
            {
                var resp = this.service.GetDepartment(id);
                return Ok(resp);
            }
            catch (Exception ex)
            {

                this._logger.Error(ex.Message);
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create(Tbdepartment dept)
        {
            try
            {
                var resp = this.service.Create(dept);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return Ok("UNSUCCESS");
            }
        }
        [HttpPut("{id}")]
       public IActionResult Update(string id, Tbdepartment dept) {
            try
            {
                var resp = this.service.Update(id, dept);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return Ok("UNSUCCESS");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var resp = this.service.Delete(id);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                this._logger.Error(ex.Message);
                return Ok("UNSUCCESS");
            }
        }
    }
}
