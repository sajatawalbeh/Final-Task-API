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
    public class MessageController : ControllerBase
    {
        private readonly IMass_MessageService messageService;
        public MessageController(IMass_MessageService messageService)
        {
            this.messageService = messageService;
        }

        [HttpGet]
        public List<Mass_messages> Getallmessage()
        {

            return messageService.Getallmessage();
        }
        [HttpPost]

        public bool createinsertmessage([FromBody] Mass_messages message)
        {
            return messageService.Createmessage(message);
        }
        [HttpPut]

        public bool Updatemessage(Mass_messages message)
        {
            return messageService.Updatemessage(message);
        }

        [HttpDelete("delete/{id}")]

        public bool deletemessage(int? id)
        {
            return messageService.Deletemessage(id);
        }
        [HttpGet("Count")]
        public int Message_Count()
        {
            return messageService.Message_Count();
        }

        [HttpPost("Search")]
        public List<Dtomessage> Search([FromBody] SearchMessageDTO D)
        {
            return messageService.Search(D);
        }
      
        [HttpGet("TotalForUser/{id}")]
        public List<string> GetTotalMessForEachUser(int id)
        {
            return messageService.GetTotalMessForEachUser(id);
        }
        [HttpGet("filter")]
        public List<MassgeFilter> filtermessage([FromBody]Mass_messages mess)
        {
            return messageService.filtermessage(mess);
        }
        [HttpGet("filter2/{c}")]
        public List<MassgeFilter> filtermessage2(char c)
        {
            return messageService.filtermessage2(c);
        }
        [HttpGet("Backup/{id}")]
        public List<string> Backup(int id)
        {
            return messageService.Backup(id);
        }













    }
}
