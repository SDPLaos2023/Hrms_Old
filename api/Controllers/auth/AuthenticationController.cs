using hrm_api.Models.auth;
using hrm_api.Services;
using hrm_api.Services.Interfaces.auth;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hrm_api.Controllers.auth
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        private readonly ILog log = LogManager.GetLogger(typeof(AuthenticationController));

        public AuthenticationController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }
        
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] LoginRequest user)
        {
            var token = this.jwtAuthenticationManager.Authenticate(user.username, user.password);
            if (token == null) {
                return Unauthorized();
            }
            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost("authenticate1")]
        public IActionResult Authenticate1([FromBody] StringLoginRequest t)
        {
            var decrData = EncrDecrServices.Decrypt(t.strRequest);

            var user = decrData.Split(',');

            var token = this.jwtAuthenticationManager.Authenticate(user[0], user[1]);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }


}
