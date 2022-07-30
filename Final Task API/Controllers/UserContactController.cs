using Massenger.Core.Data;
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
    public class UserContactController : ControllerBase
    {
        private readonly IMass_User_contactService usercontactService;
        public UserContactController(IMass_User_contactService usercontactService)
        {
            this.usercontactService = usercontactService;
        }

        [HttpGet]
        public List<Mass_user_contact> Getallusercontact()
        {

            return usercontactService.Getallusercontact();
        }
        [HttpPost]

        public bool createinsertusercontact([FromBody] Mass_user_contact user)
        {
            return usercontactService.Createusercontact(user);
        }
        [HttpPut]

        public bool Updateusercontact(Mass_user_contact user)
        {
            return usercontactService.Updateusercontact(user);
        }

        [HttpDelete("delete/{id}")]

        public bool deleteusercontact(int? id)
        {
            return usercontactService.Deleteusercontact(id);
        }
    }
}
