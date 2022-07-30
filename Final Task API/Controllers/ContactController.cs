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
    public class ContactController : ControllerBase
    {
        private readonly IMass_ContactService contactService;
        public ContactController(IMass_ContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpGet]
        public List<Mass_contacts> Getallcontact()
        {

            return contactService.Getallcontact();
        }
        [HttpPost]

        public bool createinsertcontact([FromBody] Mass_contacts contacts)
        {
            return contactService.Createcontact(contacts);
        }
        [HttpPut]

        public bool Updatecontact(Mass_contacts contacts)
        {
            return contactService.Updatecontact(contacts);
        }

        [HttpDelete("delete/{id}")]

        public bool deletecontact(int? id)
        {
            return contactService.Deletecontact(id);
        }

    }
}
