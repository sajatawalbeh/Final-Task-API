using Massenger.Core.Data;
using Massenger.Core.DTO;
using Massenger.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Task_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMass_UsersService userService;
        public UserController(IMass_UsersService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public List<Mass_users> Getalluser()
        {

            return userService.Getalluser();
        }
        [HttpPost]

        public bool createinsertuser([FromBody] Mass_users user)
        {
            return userService.Createuser(user);
        }
        [HttpPut]

        public bool Updateuser(Mass_users user)
        {
            return userService.Updateuser(user);
        }

        [HttpDelete("delete/{id}")]

        public bool deleteuser(int? id)
        {
            return userService.Deleteuser(id);
        }


        [HttpPost("InsertUserList")]

        public List<Mass_users> InsertUserList([FromBody]Mass_users[] user)
        {
            return userService.InsertUserList(user);
        }
        [HttpPost("Block")]
        public string Block([FromBody]BlockDTO block)
        {
            return userService.Block(block);
        }





    }
}
