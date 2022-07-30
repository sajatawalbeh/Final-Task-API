using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Massenger.Core.Data;
using Massenger.Core.DTO;
using Massenger.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_Task_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService JwtService;
        private readonly IEmailservice emailservice;
        public AuthController(IJwtService JwtService, IEmailservice emailservice)
        {
            this.JwtService = JwtService;
            this.emailservice = emailservice;
        }

        [HttpPost]
        public IActionResult authen([FromBody] Mass_Login login)
        {
            var RESULT = JwtService.Auth(login);

            if (RESULT == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(RESULT);


            }
        }

        [HttpPost("sendemail")]
        public IActionResult sendemail([FromBody] emailmessage mes)
        {
            string emailservice1 = emailservice.GetEmail(mes);
            if (emailservice1 == "true")
            {
                return Ok("send");


            }
            else
            {
                return BadRequest("email does not exist");
            }
        }
    }
}
