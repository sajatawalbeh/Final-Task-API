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
    public class ConversationController : ControllerBase
    {
        private readonly IMass_ConversationService ConversationService;
        public ConversationController(IMass_ConversationService ConversationService)
        {
            this.ConversationService = ConversationService;
        }

        [HttpGet]
        public List<Mass_conversation> Getallconversation()
        {

            return ConversationService.GetallConversation();
        }
        [HttpPost]

        public bool createinsertconversation([FromBody] Mass_conversation conversation)
        {
            return ConversationService.CreateConversation(conversation);
        }
        [HttpPut]

        public bool Updateconversation(Mass_conversation conversation)
        {
            return ConversationService.UpdateConversation(conversation);
        }

        [HttpDelete("delete/{id}")]

        public bool deleteconversation(int? id)
        {
            return ConversationService.DeleteConversation(id);
        }




    }
}
